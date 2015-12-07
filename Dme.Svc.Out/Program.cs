using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;

namespace Dme.Svc.Out
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            HostFactory.Run(x =>
            {
                x.Service<OutputService>();
                x.RunAsLocalService();
                x.SetDescription("EDI Output for DME WH");
                x.SetDisplayName("DME EDI Output Service");
                x.SetServiceName("dmeo");
                x.UseLog4Net();
            });
        }
    }
}
