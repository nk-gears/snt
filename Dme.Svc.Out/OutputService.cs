using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace Dme.Svc
{
    public class OutputService : BasicService
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(OutputService));
        /// <summary>
        /// Запускает службу
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public override void Init(List<Task> microServices, CancellationToken cancellationToken)
        {
            microServices.Add(Out.Mx1Export.Run(cancellationToken));
            microServices.Add(Out.АктПриемкиExport.Run(cancellationToken));
        }
    }
}
