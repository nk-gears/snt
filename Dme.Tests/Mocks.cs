using Dme.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dme.Tests
{
    public class Mocks
    {
        public static ЗаказНаРазмещениеФайл CreateЗаказНаРазмещениеФайл()
        {
            var file = new ЗаказНаРазмещениеФайл();
            file.ВерсПрог = "ru.santens.1.0";
            file.ВерсияФормата = "3.01";
            file.Имя = "ЗаказНаРазмещение_"+Guid.NewGuid().ToString();
            file.Формат = "ЗаказНаРазмещение";

            var doc = new ЗаказНаРазмещениеДокумент();
            doc.Дата = DateTime.Today.ToString("dd.MM.yyyy");
            doc.Номер = "Док_" + Guid.NewGuid().ToString();

            file.ЗаказНаРазмещениеДокумент.Add(doc);

            return file;
        }
        #region Мх1
        public static Dme.Core.Xml.Serializer CreateSerialiser_Мх1()
        {
            return Dme.Core.Xml.SerializerFactory.Default.Create<Мх1Файл>();
        }

        public static Dme.Core.Xml.Deserializer CreateDeserializer_Мх1()
        {
            return Dme.Core.Xml.DeserializerFactory.Default.Create<Мх1Файл>();
        }
        #endregion

        #region ЗаказНаРазмещение
        public static Dme.Core.Xml.Serializer CreateSerializer_ЗаказНаРазмещение()
        {
            return Dme.Core.Xml.SerializerFactory.Default.Create<ЗаказНаРазмещениеФайл>();
        }

        public static Dme.Core.Xml.Deserializer CreateDeserializer_ЗаказНаРазмещение()
        {
            return Dme.Core.Xml.DeserializerFactory.Default.Create<ЗаказНаРазмещениеФайл>();
        }
        #endregion

        #region АктПриемки
        public static Dme.Core.Xml.Serializer CreateSerialiser_АктПриемки()
        {
            return Dme.Core.Xml.SerializerFactory.Default.Create<АктПриемкиФайл>();
        }

        public static Dme.Core.Xml.Deserializer CreateDeserializer_АктПриемки()
        {
            return Dme.Core.Xml.DeserializerFactory.Default.Create<АктПриемкиФайл>();
        }
        #endregion
    }
}
