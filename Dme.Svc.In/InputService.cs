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
    public class InputService : BasicService
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(InputService));
        /// <summary>
        /// Запускает службу
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public override void Init(List<Task> microServices, CancellationToken cancellationToken)
        {
            microServices.Add(new FileWatcher(
                    Dme.Svc.Properties.Settings.Default.InputFilter,
                    Dme.Svc.Properties.Settings.Default.InputFolder,
                    Dme.Svc.Properties.Settings.Default.InputTempFolder,
                    Dme.Svc.Properties.Settings.Default.InputArchiveFolder,
                    Dme.Svc.Properties.Settings.Default.InputErrorFolder,
                    cancellationToken,
                    (path) => {
                        InputProcessorFactory
                            .Create(path)
                            .Run();
                    }
                ).Run());
        }
    }
}
