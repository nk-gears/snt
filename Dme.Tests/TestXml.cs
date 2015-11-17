using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dme.Core;
using System.Xml.Serialization;

namespace Dme.Tests
{
    [TestClass]
    public class TestXml
    {
        [TestMethod]
        public void XmlSerializer_Execute()
        {
            var file = Mocks.CreateЗаказНаРазмещениеФайл();
            var serializer = Mocks.CreateSerializer_ЗаказНаРазмещение();
            using (var textStream = System.IO.File.Create("C:\\temp\\" + file.Имя + ".xml"))
                serializer.Execute(file, textStream);
        }


        [TestMethod]
        public void XmlDeserializer_Execute()
        { 
            var deserializer = Mocks.CreateDeserializer_ЗаказНаРазмещение();
            using (var textStream = System.IO.File.Open("МХ1_Sample.xml", System.IO.FileMode.Open))
            {
                var file = (ЗаказНаРазмещениеФайл)deserializer.Execute(textStream, typeof(ЗаказНаРазмещениеФайл));
            }
        }

        [TestMethod]
        public void XmlDeserializerXmlSerializer_Execute()
        {
            using (var textStream = System.IO.File.Open("МХ1_Sample.xml", System.IO.FileMode.Open))
            {
                var deserializer = Mocks.CreateDeserializer_ЗаказНаРазмещение();
                var serializer = Mocks.CreateSerializer_ЗаказНаРазмещение();
                var file = (ЗаказНаРазмещениеФайл)deserializer.Execute(textStream, typeof(ЗаказНаРазмещениеФайл));
                using (var textStream2 = System.IO.File.Create("C:\\temp\\" + file.Имя + ".xml"))
                    serializer.Execute(file, textStream2);

            }
        }
    }
}
