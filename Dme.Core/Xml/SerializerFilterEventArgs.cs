using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dme.Core.Xml
{
    public class SerializerFilterEventArgs: EventArgs
    {
        public PropertyInfo PropInfo { get; set; }
        public object Value { get; set; }
        public bool Skip { get; set; }
    }
}
