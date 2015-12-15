using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dme.Core.Helper
{
    public class WFSTATE
    {
        public const int CREATED = 0;
        // wms states
        public const int WMS_SEND = 101;
        public const int WMS_DONE = 199;
        // acceptance states
        public const int WAIT_ACCEPT = 201;
        public const int ACCEPTED = 299;
        // sbis
        public const int SBIS = 301;
        public const int SBIS_SIGNED = 399;
    }
}
