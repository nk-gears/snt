using Dme.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace Dme.Svc.Out
{
    class OutboundExport
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(OutboundExport));
        const int DELAY = 15000;

        public static async Task Run(CancellationToken cancellationToken)
        {
            Dme.Sbis.PackageBuilder pb = new Sbis.PackageBuilder
                (
                    Dme.Svc.Out.Properties.Settings.Default.SbisOutputFolder,
                    Dme.Svc.Out.Properties.Settings.Default.RecipientID
                );

            while (!cancellationToken.IsCancellationRequested)
            {
                using (var context = new Dme.Core.DmeEntities())
                {
                    XslCompiledTransform xsltMx3 = new XslCompiledTransform();
                    xsltMx3.Load("mx3.xslt");

                    var orders = await (from o in context.Order
                                        where o.WfState == Dme.Core.Helper.WFSTATE.ACCEPTED && o.OrderType.ExportDocID == Dme.Core.Helper.EXPORTDOC.MX3
                                        select o)
                                       .ToListAsync(cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                        return;
                    foreach (var o in orders)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            break;
                        try
                        {
                            // выгрузка реестра .sbis.xml
                            pb.Begin();
                            var xml = new XDocument(Dme.Core.Xml.OrderSerializer.ToXElement(o));
                            xsltMx3.Transform(xml.CreateReader(), pb.AddFile());
                            pb.Flush();
                            // помечаем файл как выгруженный
                            o.WfState = Dme.Core.Helper.WFSTATE.SBIS;
                            await context.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {
                            log.Error(e);
                        }
                    }
                }
                if (cancellationToken.IsCancellationRequested)
                    return;
                try
                {
                    await Task.Delay(DELAY, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }
}
