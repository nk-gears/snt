using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dme.Core.Xml
{
    public class DeserializerFactory
    {
        class WellKnownEntityConfig
        {
            public EventHandler<DeserializerFilterEventArgs> OnFilter { get; set; }
            public EventHandler<DeserializerRenameEventArgs> OnRename { get; set; }
        }
        Dictionary<Type, WellKnownEntityConfig> _Config = new Dictionary<Type, WellKnownEntityConfig>();

        static DeserializerFactory _Default = null;
        public static DeserializerFactory Default
        {
            get
            {
                if (_Default == null)
                    lock (typeof(DeserializerFactory))
                    {
                        if (_Default == null)
                            _Default = new DeserializerFactory();
                    }
                return _Default;
            }
        }

        public DeserializerFactory()
        {
            // АктПриемкиФайл
            _Config.Add(typeof(АктПриемкиФайл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"@.+_Id$"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"[/]" + e.Name + "$"))
                        e.Name = "АктПриемки" + e.Name;
                }
            });
            //Мх1Файл
            _Config.Add(typeof(Мх1Файл), new WellKnownEntityConfig {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"@.+_Id$"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"[/]" + e.Name + "$"))
                        e.Name = "Мх1" + e.Name;
                }

            });
            //ЗаказНаРазмещениеФайл
            _Config.Add(typeof(ЗаказНаРазмещениеФайл), new WellKnownEntityConfig
            {
                OnFilter = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"@.+_Id$"))
                        e.Skip = true;
                },
                OnRename = (sender, e) =>
                {
                    if (Regex.IsMatch(e.XPath, @"[/]" + e.Name + "$"))
                        e.Name = "ЗаказНаРазмещение" + e.Name;
                }

            });
        }
        public Deserializer Create<T>()
        {
            if (_Config.ContainsKey(typeof(T)))
            {
                WellKnownEntityConfig cfg = _Config[typeof(T)];
                Deserializer deserializer = new Deserializer();
                deserializer.OnFilter += cfg.OnFilter;
                deserializer.OnRename += cfg.OnRename;
                return deserializer;
            }
            else
                throw new NotImplementedException();
        }
    }
}
