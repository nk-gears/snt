using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dme.Core.Xml
{
    public class DeserializerRenameEventArgs: EventArgs
    {
        public string XPath { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
}
