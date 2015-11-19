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
                var deserializer = Dme.Core.Xml.DeserializerFactory.Default.Create<ЗаказНаРазмещениеФайл>();
                var file = (ЗаказНаРазмещениеФайл)deserializer.Execute(stream);
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
