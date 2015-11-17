using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dme.Core.Xml
{
    public class SerializerRenameEventArgs : EventArgs
    {
        public Type Type { get; set; }
        public PropertyInfo PropInfo { get; set; }
        public object ObjectValue { get; set; }
        public object PropertyValue { get; set; }
        public string Name { get; set; }
    }
}
