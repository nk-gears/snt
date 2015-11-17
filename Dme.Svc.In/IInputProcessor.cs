using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dme.Svc
{
    public interface IInputProcessor
    {
        void SetDocument(XmlDocument xml);
        void Run();
    }
}
