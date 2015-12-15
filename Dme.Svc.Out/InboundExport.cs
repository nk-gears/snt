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
    class InboundExport
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(InboundExport));
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
                    XslCompiledTransform xsltMx1 = new XslCompiledTransform();
                    XslCompiledTransform xsltRep = new XslCompiledTransform();
                    xsltMx1.Load("mx1.xslt");
                    xsltRep.Load("rep.xslt");

                    var orders = await (from o in context.Order
                                        where o.WfState == Dme.Core.Helper.WFSTATE.WMS_DONE && o.OrderType.ExportDocID == Dme.Core.Helper.EXPORTDOC.MX1
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
                            xsltMx1.Transform(xml.CreateReader(), pb.AddFile());
                            if(o.IsDocEqToFact == false)
                                xsltRep.Transform(xml.CreateReader(), pb.AddFile());
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
