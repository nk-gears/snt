using Dme.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace Dme.Svc.Out
{
    class АктПриемкиExport
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Mx1Export));
        const int WF_STATE_IN = 1;
        const int WF_STATE_OUT = 2;

        public static async Task Run(CancellationToken cancellationToken)
        {
            Dme.Sbis.PackageBuilder packageBuilder = new Sbis.PackageBuilder
                (
                    Dme.Svc.Out.Properties.Settings.Default.SbisOutputFolder,
                    Dme.Svc.Out.Properties.Settings.Default.RecipientID
                );

            using (var context = new Dme.Core.DmeEntities())
            {
                var files = await(from f in context.АктПриемкиФайл
                                  where f.C_WfState == WF_STATE_IN && !f.C_Deleted
                                  select f).ToListAsync(cancellationToken);
                if (cancellationToken.IsCancellationRequested)
                    return;
                foreach (var file in files)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;
                    try
                    {
                        // выгрузка файла документа
                        string fileName = System.IO.Path.Combine(
                            Dme.Svc.Out.Properties.Settings.Default.SbisOutputFolder,
                            String.Format(Dme.Svc.Out.Properties.Settings.Default.ActAccFileNameFormat, file.Файл_Id));
                        using (var output = System.IO.File.Create(fileName))
                            await Dme.Core.Xml.SerializerFactory.Default
                                .Create<АктПриемкиФайл>()
                                .ExecuteAsync(file, output);
                        // выгрузка реестра .sbis.xml
                        packageBuilder.Begin();
                        packageBuilder.AddFile(fileName);
                        packageBuilder.Flush();
                        // помечаем файл как выгруженный
                        file.C_WfState = WF_STATE_OUT;
                        file.C_WfLastUpdateUser = String.Format("{0}\\{1}",Environment.UserDomainName,Environment.UserName);
                        file.C_WfLastUpdateDT = DateTime.Now;
                        await context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        log.Error(e);
                    }
                }
            }
        }
    }
}
