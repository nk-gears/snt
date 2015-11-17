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
    public class BasicService: Topshelf.ServiceControl
    {
        List<Task> _MicroServices = new List<Task>();

        public List<Task> MicroServices
        {
            get { return _MicroServices; }
        }
        CancellationTokenSource _CancellationTokenSource = new CancellationTokenSource();

        public CancellationTokenSource CancellationTokenSource
        {
            get { return _CancellationTokenSource; }
        }
        /// <summary>
        /// Запускает службу
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(Topshelf.HostControl hostControl)
        {
            Stop(hostControl);
            Init(this.MicroServices, this.CancellationTokenSource.Token);
            return true;
        }
        /// <summary>
        /// Останавливает службу
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(Topshelf.HostControl hostControl)
        {
            if (_MicroServices.Count > 0)
            {
                _CancellationTokenSource.Cancel();
                Task.WaitAll(_MicroServices.ToArray());
                _MicroServices.Clear();
            }
            return true;
        }

        public virtual void Init(List<Task> microServices, CancellationToken cancellationToken)
        {
        }
    }
}
