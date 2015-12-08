using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dme.B2B.Inventory
{
    [DataContract]
    public class Запас
    {
        public string Код { get; set; }
        public string Серия { get; set; }
        public DateTime СрокГодности { get; set; }
        public string Качество { get; set; }
        public string Маркер { get; set; }
        public int Кол_во { get; set; }
    }
    public class ЗапасКоллекция : Collection<Запас> { }
}
