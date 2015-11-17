using System;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Data.Entity;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dme.Core;
using System.Xml.Serialization;


namespace Dme.Tests
{
    [TestClass]
    public class TestXmlAndEF
    {
        [TestMethod]
        public void Xml_To_DB()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var deserializer = Mocks.CreateDeserializer_ЗаказНаРазмещение();
                using (var textStream = System.IO.File.Open("МХ1_Sample.xml", System.IO.FileMode.Open))
                {
                    var file = (ЗаказНаРазмещениеФайл)deserializer.Execute(textStream, typeof(ЗаказНаРазмещениеФайл));
                    context.ЗаказНаРазмещениеФайл.Add(file);
                    context.SaveChanges();
                }
            }
        }
        [TestMethod]
        public void DB_To_Xml()
        {
            var serializer = Mocks.CreateSerializer_ЗаказНаРазмещение();
            using (var context = new Dme.Core.DmeEntities())
            {
                var q = from f in context.ЗаказНаРазмещениеФайл
                        select f;
                foreach (var f in q)
                {
                    using (var textStream = System.IO.File.Create("C:\\temp\\Файл_Id_" + f.Файл_Id.ToString() + ".xml"))
                        serializer.Execute(f, textStream, typeof(ЗаказНаРазмещениеФайл));
                }
            }
        }
    }
}
