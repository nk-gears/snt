﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace Dme.B2B.Inbound
{
		[Serializable]
		[DataContract]
		public partial class Файл
		{
				[DataMember]
				[XmlAttribute]
				public String ВерсПрог { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ВерсияФормата { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Имя { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Формат { get; set; }
				[DataMember]
				[XmlAttribute]
				public String КодФормы { get; set; }
				[DataMember]
				public ДокументКоллекция Документ { get; set; }
		}

		[CollectionDataContract]
		public class ФайлКоллекция : Collection<Файл> {}

		[Serializable]
		[DataContract]
		public partial class Документ
		{
				[DataMember]
				[XmlAttribute]
				public String Дата { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Номер { get; set; }
				[DataMember]
				public ОснованиеКоллекция Основание { get; set; }
				[DataMember]
				public ОтправительКоллекция Отправитель { get; set; }
				[DataMember]
				public ПолучательКоллекция Получатель { get; set; }
				[DataMember]
				public ТаблДокКоллекция ТаблДок { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ДокументКоллекция : Collection<Документ> {}

		[Serializable]
		[DataContract]
		public partial class Основание
		{
				[DataMember]
				[XmlAttribute]
				public String Номер { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Дата { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Наим { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? СуммаБезНал { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? Сумма { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Срок { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ОснованиеКоллекция : Collection<Основание> {}

		[Serializable]
		[DataContract]
		public partial class Отправитель
		{
				[DataMember]
				[XmlAttribute]
				public String Роль { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				public АдресКоллекция Адрес { get; set; }
				[DataMember]
				public ПредставительКоллекция Представитель { get; set; }
				[DataMember]
				public БанкРеквКоллекция БанкРекв { get; set; }
				[DataMember]
				public КонтактКоллекция Контакт { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
				[DataMember]
				public ПодразделениеКоллекция Подразделение { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
				[DataMember]
				public СвЮЛКоллекция СвЮЛ { get; set; }
		}

		[CollectionDataContract]
		public class ОтправительКоллекция : Collection<Отправитель> {}

		[Serializable]
		[DataContract]
		public partial class Получатель
		{
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				public АдресКоллекция Адрес { get; set; }
				[DataMember]
				public БанкРеквКоллекция БанкРекв { get; set; }
				[DataMember]
				public КонтактКоллекция Контакт { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
				[DataMember]
				public ПодразделениеКоллекция Подразделение { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
				[DataMember]
				public СвЮЛКоллекция СвЮЛ { get; set; }
		}

		[CollectionDataContract]
		public class ПолучательКоллекция : Collection<Получатель> {}

		[Serializable]
		[DataContract]
		public partial class ТаблДок
		{
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Тип { get; set; }
				[DataMember]
				public ИтогТаблКоллекция ИтогТабл { get; set; }
				[DataMember]
				public СтрТаблКоллекция СтрТабл { get; set; }
		}

		[CollectionDataContract]
		public class ТаблДокКоллекция : Collection<ТаблДок> {}

		[Serializable]
		[DataContract]
		public partial class Параметр
		{
				[DataMember]
				[XmlAttribute]
				public String Имя { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Значение { get; set; }
		}

		[CollectionDataContract]
		public class ПараметрКоллекция : Collection<Параметр> {}

		[Serializable]
		[DataContract]
		public partial class Адрес
		{
				[DataMember]
				[XmlAttribute]
				public String Тип { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Наим { get; set; }
				[DataMember]
				[XmlAttribute]
				public String АдрТекст { get; set; }
				[DataMember]
				public АдрИноКоллекция АдрИно { get; set; }
				[DataMember]
				public АдрРФКоллекция АдрРФ { get; set; }
		}

		[CollectionDataContract]
		public class АдресКоллекция : Collection<Адрес> {}

		[Serializable]
		[DataContract]
		public partial class Представитель
		{
				[DataMember]
				[XmlAttribute]
				public String Должность { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Роль { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
		}

		[CollectionDataContract]
		public class ПредставительКоллекция : Collection<Представитель> {}

		[Serializable]
		[DataContract]
		public partial class БанкРекв
		{
				[DataMember]
				[XmlAttribute]
				public String НаимБанк { get; set; }
				[DataMember]
				[XmlAttribute]
				public String БИК { get; set; }
				[DataMember]
				[XmlAttribute]
				public String РСчет { get; set; }
				[DataMember]
				[XmlAttribute]
				public String КСчет { get; set; }
		}

		[CollectionDataContract]
		public class БанкРеквКоллекция : Collection<БанкРекв> {}

		[Serializable]
		[DataContract]
		public partial class Контакт
		{
				[DataMember]
				[XmlAttribute]
				public String Телефон { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Факс { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Email { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Internet { get; set; }
		}

		[CollectionDataContract]
		public class КонтактКоллекция : Collection<Контакт> {}

		[Serializable]
		[DataContract]
		public partial class Подразделение
		{
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Идентификатор { get; set; }
		}

		[CollectionDataContract]
		public class ПодразделениеКоллекция : Collection<Подразделение> {}

		[Serializable]
		[DataContract]
		public partial class СвФЛ
		{
				[DataMember]
				[XmlAttribute]
				public String ИНН { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Фамилия { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Имя { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Отчество { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Обращение { get; set; }
		}

		[CollectionDataContract]
		public class СвФЛКоллекция : Collection<СвФЛ> {}

		[Serializable]
		[DataContract]
		public partial class СвЮЛ
		{
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ИНН { get; set; }
				[DataMember]
				[XmlAttribute]
				public String КПП { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ОКДП { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ОКПО { get; set; }
		}

		[CollectionDataContract]
		public class СвЮЛКоллекция : Collection<СвЮЛ> {}

		[Serializable]
		[DataContract]
		public partial class ИтогТабл
		{
				[DataMember]
				[XmlAttribute]
				public String Тип { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? Нетто { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? СуммаБезНал { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? Кол_во { get; set; }
				[DataMember]
				[XmlAttribute]
				public Single? Сумма { get; set; }
				[DataMember]
				public НДСКоллекция НДС { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
				[DataMember]
				public ХарактеристикаКоллекция Характеристика { get; set; }
		}

		[CollectionDataContract]
		public class ИтогТаблКоллекция : Collection<ИтогТабл> {}

		[Serializable]
		[DataContract]
		public partial class СтрТабл
		{
				[DataMember]
				[XmlAttribute]
				public String ПорНомер { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Название { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int32? Кол_во { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ЕдИзм { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ОКЕИ { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Код { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Цена { get; set; }
				[DataMember]
				[XmlAttribute]
				public Decimal? СуммаБезНал { get; set; }
				[DataMember]
				[XmlAttribute]
				public Decimal? Сумма { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Примечание { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Описание { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Серия { get; set; }
				[DataMember]
				[XmlAttribute]
				public DateTime? СрокГодности { get; set; }
				[DataMember]
				[XmlAttribute]
				public DateTime? ДатаИзг { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ШтрихКод { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Качество { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ТемпРежим { get; set; }
				[DataMember]
				[XmlAttribute]
				public String КлассОпасн { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Производитель { get; set; }
				[DataMember]
				[XmlAttribute]
				public Boolean? Стекло { get; set; }
				[DataMember]
				[XmlAttribute]
				public Boolean? Пку { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ОригПорНомер { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? МинЗаказ { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? КратнЗаказ { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Маркер { get; set; }
				[DataMember]
				public НДСКоллекция НДС { get; set; }
				[DataMember]
				public РазмерКоробкиКоллекция РазмерКоробки { get; set; }
				[DataMember]
				public РазмерМалСтандартКоллекция РазмерМалСтандарт { get; set; }
				[DataMember]
				public РазмерУпаковкиКоллекция РазмерУпаковки { get; set; }
				[DataMember]
				public ХарактеристикаКоллекция Характеристика { get; set; }
		}

		[CollectionDataContract]
		public class СтрТаблКоллекция : Collection<СтрТабл> {}

		[Serializable]
		[DataContract]
		public partial class АдрИно
		{
				[DataMember]
				[XmlAttribute]
				public String КодСтр { get; set; }
				[DataMember]
				[XmlAttribute]
				public String АдрТекст { get; set; }
		}

		[CollectionDataContract]
		public class АдрИноКоллекция : Collection<АдрИно> {}

		[Serializable]
		[DataContract]
		public partial class АдрРФ
		{
				[DataMember]
				[XmlAttribute]
				public String Индекс { get; set; }
				[DataMember]
				[XmlAttribute]
				public String КодРегион { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Район { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Город { get; set; }
				[DataMember]
				[XmlAttribute]
				public String НаселПункт { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Улица { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Дом { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Корпус { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Кварт { get; set; }
		}

		[CollectionDataContract]
		public class АдрРФКоллекция : Collection<АдрРФ> {}

		[Serializable]
		[DataContract]
		public partial class НДС
		{
				[DataMember]
				[XmlAttribute]
				public String Наим { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Ставка { get; set; }
				[DataMember]
				[XmlAttribute]
				public String ТипСтавки { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Сумма { get; set; }
		}

		[CollectionDataContract]
		public class НДСКоллекция : Collection<НДС> {}

		[Serializable]
		[DataContract]
		public partial class Характеристика
		{
				[DataMember]
				[XmlAttribute]
				public String Имя { get; set; }
				[DataMember]
				[XmlAttribute]
				public String Значение { get; set; }
		}

		[CollectionDataContract]
		public class ХарактеристикаКоллекция : Collection<Характеристика> {}

		[Serializable]
		[DataContract]
		public partial class РазмерКоробки
		{
				[DataMember]
				[XmlAttribute]
				public Int64? Кол_воУп { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Ширина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Длина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Высота { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Вес { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Объем { get; set; }
		}

		[CollectionDataContract]
		public class РазмерКоробкиКоллекция : Collection<РазмерКоробки> {}

		[Serializable]
		[DataContract]
		public partial class РазмерМалСтандарт
		{
				[DataMember]
				[XmlAttribute]
				public Int64? Кол_воУп { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Ширина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Длина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Высота { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Вес { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Объем { get; set; }
		}

		[CollectionDataContract]
		public class РазмерМалСтандартКоллекция : Collection<РазмерМалСтандарт> {}

		[Serializable]
		[DataContract]
		public partial class РазмерУпаковки
		{
				[DataMember]
				[XmlAttribute]
				public Int64? Ширина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Длина { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Высота { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Вес { get; set; }
				[DataMember]
				[XmlAttribute]
				public Int64? Объем { get; set; }
		}

		[CollectionDataContract]
		public class РазмерУпаковкиКоллекция : Collection<РазмерУпаковки> {}


		static class DataContractMapperCfg
		{
				public static void Initialize()
				{
						AutoMapper.Mapper.Initialize(cfg => {
								cfg.ClearPrefixes();
								cfg.RecognizeDestinationPrefixes(new string[] { "ЗаказНаРазмещение" });
								cfg.CreateMap<Файл, Core.ЗаказНаРазмещениеФайл>();
								cfg.CreateMap<Документ, Core.ЗаказНаРазмещениеДокумент>();
								cfg.CreateMap<Основание, Core.ЗаказНаРазмещениеОснование>();
								cfg.CreateMap<Отправитель, Core.ЗаказНаРазмещениеОтправитель>();
								cfg.CreateMap<Получатель, Core.ЗаказНаРазмещениеПолучатель>();
								cfg.CreateMap<ТаблДок, Core.ЗаказНаРазмещениеТаблДок>();
								cfg.CreateMap<Параметр, Core.ЗаказНаРазмещениеПараметр>();
								cfg.CreateMap<Адрес, Core.ЗаказНаРазмещениеАдрес>();
								cfg.CreateMap<Представитель, Core.ЗаказНаРазмещениеПредставитель>();
								cfg.CreateMap<БанкРекв, Core.ЗаказНаРазмещениеБанкРекв>();
								cfg.CreateMap<Контакт, Core.ЗаказНаРазмещениеКонтакт>();
								cfg.CreateMap<Подразделение, Core.ЗаказНаРазмещениеПодразделение>();
								cfg.CreateMap<СвФЛ, Core.ЗаказНаРазмещениеСвФЛ>();
								cfg.CreateMap<СвЮЛ, Core.ЗаказНаРазмещениеСвЮЛ>();
								cfg.CreateMap<ИтогТабл, Core.ЗаказНаРазмещениеИтогТабл>();
								cfg.CreateMap<СтрТабл, Core.ЗаказНаРазмещениеСтрТабл>();
								cfg.CreateMap<АдрИно, Core.ЗаказНаРазмещениеАдрИно>();
								cfg.CreateMap<АдрРФ, Core.ЗаказНаРазмещениеАдрРФ>();
								cfg.CreateMap<НДС, Core.ЗаказНаРазмещениеНДС>();
								cfg.CreateMap<Характеристика, Core.ЗаказНаРазмещениеХарактеристика>();
								cfg.CreateMap<РазмерКоробки, Core.ЗаказНаРазмещениеРазмерКоробки>();
								cfg.CreateMap<РазмерМалСтандарт, Core.ЗаказНаРазмещениеРазмерМалСтандарт>();
								cfg.CreateMap<РазмерУпаковки, Core.ЗаказНаРазмещениеРазмерУпаковки>();
								cfg.ClearPrefixes();
								cfg.RecognizePrefixes(new string[] { "ЗаказНаРазмещение" });
								cfg.CreateMap<Core.ЗаказНаРазмещениеФайл, Файл>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеДокумент, Документ>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеОснование, Основание>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеОтправитель, Отправитель>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеПолучатель, Получатель>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеТаблДок, ТаблДок>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеПараметр, Параметр>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеАдрес, Адрес>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеПредставитель, Представитель>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеБанкРекв, БанкРекв>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеКонтакт, Контакт>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеПодразделение, Подразделение>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеСвФЛ, СвФЛ>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеСвЮЛ, СвЮЛ>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеИтогТабл, ИтогТабл>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеСтрТабл, СтрТабл>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеАдрИно, АдрИно>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеАдрРФ, АдрРФ>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеНДС, НДС>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеХарактеристика, Характеристика>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеРазмерКоробки, РазмерКоробки>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеРазмерМалСтандарт, РазмерМалСтандарт>();
								cfg.CreateMap<Core.ЗаказНаРазмещениеРазмерУпаковки, РазмерУпаковки>();
						});
				}
		}
}

