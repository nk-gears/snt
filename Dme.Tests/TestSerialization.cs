using System;
using System.Linq;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Platform.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace Dme.Tests
{
    [TestClass]
    public class TestSerialization
    {
        [TestMethod]
        public void TestPlatformXmlSerializer()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var order = context.Order.Where(o=>o.OrderID== 2499).First();
                var doc = new XDocument(Dme.Core.Xml.OrderSerializer.ToXElement(order));
                
                doc.Save(@"c:\temp\snt\test.xml");
            }
        }
    }
}
