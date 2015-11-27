using System;
using System.Linq;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dme.Core;
using System.Globalization;

namespace Dme.Tests
{
    [TestClass]
    public class TestGDP
    {
        [TestMethod]
        public void GDP_Мх1()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var files = (from f in context.Мх1Файл 
                             select f).Take(10);
                foreach (var file in files)
                {
                    using (var output = System.IO.File.Create(System.IO.Path.Combine(@"C:\temp\snt\out", "Мх1_" + file.Файл_Id.ToString() + ".xml")))
                        Dme.Core.Xml.SerializerFactory.Default.Create<Мх1Файл>().Execute(file, output);
                }
            }
        }
        [TestMethod]
        public void GDP_Мх3()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var files = (from f in context.Мх3Файл
                             select f).Take(10);
                foreach (var file in files)
                {
                    using (var output = System.IO.File.Create(System.IO.Path.Combine(@"C:\temp\snt\out", "Мх3_" + file.Файл_Id.ToString() + ".xml")))
                        Dme.Core.Xml.SerializerFactory.Default.Create<Мх3Файл>().Execute(file, output);
                }
            }
        }
        [TestMethod]
        public void GDP_АктПриемки()
        {
            using (var context = new Dme.Core.DmeEntities())
            {
                var files = (from f in context.АктПриемкиФайл
                             select f).Take(10);
                foreach (var file in files)
                {
                    using (var output = System.IO.File.Create(System.IO.Path.Combine(@"C:\temp\snt\out", "АктПриемки_" + file.Файл_Id.ToString() + ".xml")))
                        Dme.Core.Xml.SerializerFactory.Default.Create<АктПриемкиФайл>().Execute(file, output);
                }
            }
        }
    }
}
