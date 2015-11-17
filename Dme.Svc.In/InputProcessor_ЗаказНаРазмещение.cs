using Dme.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Dme.Svc
{
    class InputProcessor_ЗаказНаРазмещение: IInputProcessor, IDisposable
    {
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(InputProcessor_ЗаказНаРазмещение));
        XmlDocument _xml;
        DmeEntities _Context = new Dme.Core.DmeEntities();
        void InputProcessor()
        {
        }
        /// <summary>
        /// Обрабатывает файл
        /// </summary>
        /// <param name="fileName"></param>
        void IInputProcessor.Run()
        {
            using (var stream = new MemoryStream())
            {
                _xml.Save(stream);
                stream.Position = 0;
                var deserializer = CreateDeserializer();
                var file = (ЗаказНаРазмещениеФайл)deserializer.Execute(stream, typeof(ЗаказНаРазмещениеФайл));
                _Context.ЗаказНаРазмещениеФайл.Add(file);
                _Context.SaveChanges();
            }
        }
        /// <summary>
        /// Устанавливает текущий докмуент для обработки
        /// </summary>
        /// <param name="xml"></param>
        void IInputProcessor.SetDocument(XmlDocument xml)
        {
            _xml = xml;
        }

        public Dme.Core.Xml.Deserializer CreateDeserializer()
        {
            var deserializer = new Dme.Core.Xml.Deserializer();
            deserializer.OnFilter += deserializer_OnFilter;
            deserializer.OnRename += deserializer_OnRename;
            return deserializer;
        }

        void deserializer_OnRename(object sender, Core.Xml.DeserializerRenameEventArgs e)
        {
            if (Regex.IsMatch(e.XPath, @"[/]" + e.Name + "$"))
                e.Name = "ЗаказНаРазмещение" + e.Name;
        }

        void deserializer_OnFilter(object sender, Core.Xml.DeserializerFilterEventArgs e)
        {
            if (Regex.IsMatch(e.XPath, @"@.+_Id$"))
                e.Skip = true;
        }
    
        public void Dispose()
        {
 	        if(_Context!=null)
            {
                _Context.Dispose();
                _Context = null;
            }
        }
    }
}
