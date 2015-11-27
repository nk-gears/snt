using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dme.Core.Xml
{
    public class SerializerFactory
    {
        class WellKnownEntityConfig
        {
            public EventHandler<SerializerFilterEventArgs> OnFilter { get; set; }
            public EventHandler<SerializerRenameEventArgs> OnRename { get; set; }
        }
        Dictionary<Type, WellKnownEntityConfig> _Config = new Dictionary<Type, WellKnownEntityConfig>();
        
        static SerializerFactory _Default = null;
        public static SerializerFactory Default
        {
            get 
            {
                if (_Default == null)
                    lock (typeof(SerializerFactory))
                    {
                        if (_Default == null)
                            _Default = new SerializerFactory();
                    }
                return _Default;
            }
        }

        public SerializerFactory()
        {
            // АктПриемкиФайл
            _Config.Add(typeof(АктПриемкиФайл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.PropInfo.Name, @"_Id$"))
                        e.Skip = true;
                    else if (Regex.IsMatch(e.PropInfo.Name, @"^C[_]"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    e.Name = Regex.Replace(e.Name, @"^АктПриемки", "");
                }
            });
            //Мх1Файл
            _Config.Add(typeof(Мх1Файл), new WellKnownEntityConfig {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.PropInfo.Name, @"_Id$"))
                        e.Skip = true;
                    else if (Regex.IsMatch(e.PropInfo.Name, @"^C[_]"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    e.Name = Regex.Replace(e.Name, @"^Мх1", "");
                }

            });
            //Мх3Файл
            _Config.Add(typeof(Мх3Файл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.PropInfo.Name, @"_Id$"))
                        e.Skip = true;
                    else if (Regex.IsMatch(e.PropInfo.Name, @"^C[_]"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    e.Name = Regex.Replace(e.Name, @"^Мх3", "");
                }

            });
            //ЗаказНаРазмещениеФайл
            _Config.Add(typeof(ЗаказНаРазмещениеФайл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.PropInfo.Name, @"_Id$"))
                        e.Skip = true;
                    else if (Regex.IsMatch(e.PropInfo.Name, @"^C[_]"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    e.Name = Regex.Replace(e.Name, @"^ЗаказНаРазмещение", "");
                }

            });
            //ЗаказНаОтгрузкуФайл
            _Config.Add(typeof(ЗаказНаОтгрузкуФайл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.PropInfo.Name, @"_Id$"))
                        e.Skip = true;
                    else if (Regex.IsMatch(e.PropInfo.Name, @"^C[_]"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    e.Name = Regex.Replace(e.Name, @"^ЗаказНаОтгрузку", "");
                }

            });
        }


        public Serializer Create<T>()
        {
            if (_Config.ContainsKey(typeof(T)))
            {
                WellKnownEntityConfig cfg = _Config[typeof(T)];
                Serializer serializer = new Serializer(typeof(T));
                serializer.OnFilter += cfg.OnFilter;
                serializer.OnRename += cfg.OnRename;
                return serializer;
            }
            else
                throw new NotImplementedException();
        }
    }
}
