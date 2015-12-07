using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;

namespace Dme.Svc
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            HostFactory.Run(x => {
                x.Service<InputService>();
                x.RunAsLocalService();
                x.SetDescription("EDI Input for DME WH");
                x.SetDisplayName("DME EDI Input Service");
                x.SetServiceName("dmei");
                x.UseLog4Net();
            });
        }
    }
}
