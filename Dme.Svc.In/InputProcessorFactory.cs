using System;
using System.Collections.Generic;
using System.Xml;

namespace Dme.Svc
{
    public class InputProcessorFactory
    {
        class InputProcessorRec
        {
            public Func<XmlDocument, bool> Test { get; set; }
            public IInputProcessor Processor { get; set; }
        }
        static volatile List<InputProcessorRec> _Formats = null;

        static List<InputProcessorRec> GetFormats()
        {
            if(_Formats==null)
                lock (typeof(InputProcessorFactory))
                {
                    if (_Formats == null)
                    {
                        _Formats = new List<InputProcessorRec>();
                        /*
                        _Formats.Add(new InputProcessorRec
                        {
                            Test = (xml) => { return xml.DocumentElement.Attributes["Формат"].Value == "ЗаказНаРазмещение"; },
                            Processor = new InputProcessor_ЗаказНаРазмещение()
                        }); */
                    }
                }
            return _Formats;
        }

        public static IInputProcessor Create(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            foreach (var format in GetFormats())
                if (format.Test(xml))
                {
                    IInputProcessor processor = format.Processor;
                    processor.SetDocument(xml);
                    return processor;
                }
            throw new Exception(String.Format("Failed to determine processor for {0}", fileName));
        }
    }
}
