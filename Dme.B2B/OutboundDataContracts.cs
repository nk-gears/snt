using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Text;

namespace Dme.B2B.Outbound
{
		[Serializable]
		[DataContract]
		public partial class Файл
		{
				[DataMember]
				public String ИдФайл { get; set; }
				[DataMember]
				public String ВерсПрог { get; set; }
				[DataMember]
				public String ИдФорм { get; set; }
				[DataMember]
				public String ВерсФорм { get; set; }
				[DataMember]
				public String Сформирован { get; set; }
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
				public String Дата { get; set; }
				[DataMember]
				public String Номер { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
				[DataMember]
				public String Примечание { get; set; }
				[DataMember]
				public ОснованиеКоллекция Основание { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
				[DataMember]
				public ТаблицаКоллекция Таблица { get; set; }
				[DataMember]
				public УчастникКоллекция Участник { get; set; }
		}

		[CollectionDataContract]
		public class ДокументКоллекция : Collection<Документ> {}

		[Serializable]
		[DataContract]
		public partial class Основание
		{
				[DataMember]
				public String Номер { get; set; }
				[DataMember]
				public String Дата { get; set; }
				[DataMember]
				public String КодОКВ { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public Decimal? СуммаБезНал { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
				[DataMember]
				public String СрокОплаты { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ОснованиеКоллекция : Collection<Основание> {}

		[Serializable]
		[DataContract]
		public partial class Параметр
		{
				[DataMember]
				public String Имя { get; set; }
				[DataMember]
				public String Значение { get; set; }
		}

		[CollectionDataContract]
		public class ПараметрКоллекция : Collection<Параметр> {}

		[Serializable]
		[DataContract]
		public partial class Таблица
		{
				[DataMember]
				public String Тип { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public ИтогТаблКоллекция ИтогТабл { get; set; }
				[DataMember]
				public СтрТаблКоллекция СтрТабл { get; set; }
		}

		[CollectionDataContract]
		public class ТаблицаКоллекция : Collection<Таблица> {}

		[Serializable]
		[DataContract]
		public partial class Участник
		{
				[DataMember]
				public String Роль { get; set; }
				[DataMember]
				public АдресКоллекция Адрес { get; set; }
				[DataMember]
				public БанкРеквКоллекция БанкРекв { get; set; }
				[DataMember]
				public КонтактКоллекция Контакт { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
				[DataMember]
				public ПредставительКоллекция Представитель { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
				[DataMember]
				public СвЮЛКоллекция СвЮЛ { get; set; }
		}

		[CollectionDataContract]
		public class УчастникКоллекция : Collection<Участник> {}

		[Serializable]
		[DataContract]
		public partial class ИтогТабл
		{
				[DataMember]
				public String Тип { get; set; }
				[DataMember]
				public Int32? Кол_во { get; set; }
				[DataMember]
				public Decimal? Нетто { get; set; }
				[DataMember]
				public Decimal? Брутто { get; set; }
				[DataMember]
				public Decimal? СуммаБезНал { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
				[DataMember]
				public String Примечание { get; set; }
				[DataMember]
				public НалогКоллекция Налог { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ИтогТаблКоллекция : Collection<ИтогТабл> {}

		[Serializable]
		[DataContract]
		public partial class СтрТабл
		{
				[DataMember]
				public String ПорНомер { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public Int32? Кол_во { get; set; }
				[DataMember]
				public String ЕдИзм { get; set; }
				[DataMember]
				public String ОКЕИ { get; set; }
				[DataMember]
				public Decimal? Цена { get; set; }
				[DataMember]
				public Decimal? СуммаБезНал { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
				[DataMember]
				public String Примечание { get; set; }
				[DataMember]
				public String Описание { get; set; }
				[DataMember]
				public НалогКоллекция Налог { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class СтрТаблКоллекция : Collection<СтрТабл> {}

		[Serializable]
		[DataContract]
		public partial class Адрес
		{
				[DataMember]
				public String Тип { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public АдрИноКоллекция АдрИно { get; set; }
				[DataMember]
				public АдрРФКоллекция АдрРФ { get; set; }
		}

		[CollectionDataContract]
		public class АдресКоллекция : Collection<Адрес> {}

		[Serializable]
		[DataContract]
		public partial class БанкРекв
		{
				[DataMember]
				public String НаимБанк { get; set; }
				[DataMember]
				public String БИК { get; set; }
				[DataMember]
				public String РСчет { get; set; }
				[DataMember]
				public String КСчет { get; set; }
		}

		[CollectionDataContract]
		public class БанкРеквКоллекция : Collection<БанкРекв> {}

		[Serializable]
		[DataContract]
		public partial class Контакт
		{
				[DataMember]
				public String Телефон { get; set; }
				[DataMember]
				public String Факс { get; set; }
				[DataMember]
				public String Email { get; set; }
				[DataMember]
				public String Internet { get; set; }
		}

		[CollectionDataContract]
		public class КонтактКоллекция : Collection<Контакт> {}

		[Serializable]
		[DataContract]
		public partial class Представитель
		{
				[DataMember]
				public String Должность { get; set; }
				[DataMember]
				public String Роль { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
		}

		[CollectionDataContract]
		public class ПредставительКоллекция : Collection<Представитель> {}

		[Serializable]
		[DataContract]
		public partial class СвФЛ
		{
				[DataMember]
				public String ИНН { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public String Фамилия { get; set; }
				[DataMember]
				public String Имя { get; set; }
				[DataMember]
				public String Отчество { get; set; }
				[DataMember]
				public String Обращение { get; set; }
		}

		[CollectionDataContract]
		public class СвФЛКоллекция : Collection<СвФЛ> {}

		[Serializable]
		[DataContract]
		public partial class СвЮЛ
		{
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public String ОфицНаим { get; set; }
				[DataMember]
				public String ИНН { get; set; }
				[DataMember]
				public String КПП { get; set; }
				[DataMember]
				public String ОКДП { get; set; }
				[DataMember]
				public String ОКПО { get; set; }
		}

		[CollectionDataContract]
		public class СвЮЛКоллекция : Collection<СвЮЛ> {}

		[Serializable]
		[DataContract]
		public partial class Налог
		{
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public String Ставка { get; set; }
				[DataMember]
				public String ТипСтавки { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
		}

		[CollectionDataContract]
		public class НалогКоллекция : Collection<Налог> {}

		[Serializable]
		[DataContract]
		public partial class АдрИно
		{
				[DataMember]
				public String КодСтр { get; set; }
				[DataMember]
				public String АдрТекст { get; set; }
		}

		[CollectionDataContract]
		public class АдрИноКоллекция : Collection<АдрИно> {}

		[Serializable]
		[DataContract]
		public partial class АдрРФ
		{
				[DataMember]
				public String Индекс { get; set; }
				[DataMember]
				public String КодРегион { get; set; }
				[DataMember]
				public String Район { get; set; }
				[DataMember]
				public String Город { get; set; }
				[DataMember]
				public String НаселПункт { get; set; }
				[DataMember]
				public String Улица { get; set; }
				[DataMember]
				public String Дом { get; set; }
				[DataMember]
				public String Корпус { get; set; }
				[DataMember]
				public String Кварт { get; set; }
		}

		[CollectionDataContract]
		public class АдрРФКоллекция : Collection<АдрРФ> {}


		static class DataContractMapperCfg
		{
				public static void Initialize()
				{
						AutoMapper.Mapper.Initialize(cfg => {
								cfg.ClearPrefixes();
								cfg.RecognizeDestinationPrefixes(new string[] { "ЗаказНаОтгрузку" });
								cfg.CreateMap<Файл, Core.ЗаказНаОтгрузкуФайл>();
								cfg.CreateMap<Документ, Core.ЗаказНаОтгрузкуДокумент>();
								cfg.CreateMap<Основание, Core.ЗаказНаОтгрузкуОснование>();
								cfg.CreateMap<Параметр, Core.ЗаказНаОтгрузкуПараметр>();
								cfg.CreateMap<Таблица, Core.ЗаказНаОтгрузкуТаблица>();
								cfg.CreateMap<Участник, Core.ЗаказНаОтгрузкуУчастник>();
								cfg.CreateMap<ИтогТабл, Core.ЗаказНаОтгрузкуИтогТабл>();
								cfg.CreateMap<СтрТабл, Core.ЗаказНаОтгрузкуСтрТабл>();
								cfg.CreateMap<Адрес, Core.ЗаказНаОтгрузкуАдрес>();
								cfg.CreateMap<БанкРекв, Core.ЗаказНаОтгрузкуБанкРекв>();
								cfg.CreateMap<Контакт, Core.ЗаказНаОтгрузкуКонтакт>();
								cfg.CreateMap<Представитель, Core.ЗаказНаОтгрузкуПредставитель>();
								cfg.CreateMap<СвФЛ, Core.ЗаказНаОтгрузкуСвФЛ>();
								cfg.CreateMap<СвЮЛ, Core.ЗаказНаОтгрузкуСвЮЛ>();
								cfg.CreateMap<Налог, Core.ЗаказНаОтгрузкуНалог>();
								cfg.CreateMap<АдрИно, Core.ЗаказНаОтгрузкуАдрИно>();
								cfg.CreateMap<АдрРФ, Core.ЗаказНаОтгрузкуАдрРФ>();
								cfg.ClearPrefixes();
								cfg.RecognizePrefixes(new string[] { "ЗаказНаОтгрузку" });
								cfg.CreateMap<Core.ЗаказНаОтгрузкуФайл, Файл>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуДокумент, Документ>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуОснование, Основание>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуПараметр, Параметр>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуТаблица, Таблица>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуУчастник, Участник>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуИтогТабл, ИтогТабл>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуСтрТабл, СтрТабл>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуАдрес, Адрес>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуБанкРекв, БанкРекв>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуКонтакт, Контакт>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуПредставитель, Представитель>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуСвФЛ, СвФЛ>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуСвЮЛ, СвЮЛ>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуНалог, Налог>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуАдрИно, АдрИно>();
								cfg.CreateMap<Core.ЗаказНаОтгрузкуАдрРФ, АдрРФ>();
						});
				}
		}
}

