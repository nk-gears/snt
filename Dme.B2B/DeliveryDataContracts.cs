using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.ObjectModel;
using System.Text;

namespace Dme.B2B.Delivery
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
				public DateTime? Сформирован { get; set; }
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
				public DateTime? Дата { get; set; }
				[DataMember]
				public String Номер { get; set; }
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
		public partial class Отправитель
		{
				[DataMember]
				public String Название { get; set; }
				[DataMember]
				public АдресКоллекция Адрес { get; set; }
				[DataMember]
				public КонтактКоллекция Контакт { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
				[DataMember]
				public СвЮЛКоллекция СвЮЛ { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ОтправительКоллекция : Collection<Отправитель> {}

		[Serializable]
		[DataContract]
		public partial class Получатель
		{
				[DataMember]
				public String Название { get; set; }
				[DataMember]
				public АдресКоллекция Адрес { get; set; }
				[DataMember]
				public КонтактКоллекция Контакт { get; set; }
				[DataMember]
				public СвФЛКоллекция СвФЛ { get; set; }
				[DataMember]
				public СвЮЛКоллекция СвЮЛ { get; set; }
				[DataMember]
				public ПараметрКоллекция Параметр { get; set; }
		}

		[CollectionDataContract]
		public class ПолучательКоллекция : Collection<Получатель> {}

		[Serializable]
		[DataContract]
		public partial class ТаблДок
		{
				[DataMember]
				public String Название { get; set; }
				[DataMember]
				public String Тип { get; set; }
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
				public String Имя { get; set; }
				[DataMember]
				public String Значение { get; set; }
		}

		[CollectionDataContract]
		public class ПараметрКоллекция : Collection<Параметр> {}

		[Serializable]
		[DataContract]
		public partial class Адрес
		{
				[DataMember]
				public String Тип { get; set; }
				[DataMember]
				public String Наим { get; set; }
				[DataMember]
				public String АдрТекст { get; set; }
		}

		[CollectionDataContract]
		public class АдресКоллекция : Collection<Адрес> {}

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
		public partial class СвФЛ
		{
				[DataMember]
				public String ИНН { get; set; }
				[DataMember]
				public String Название { get; set; }
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
				public String Название { get; set; }
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
		public partial class СтрТабл
		{
				[DataMember]
				public Int32? ПорНомер { get; set; }
				[DataMember]
				public String Название { get; set; }
				[DataMember]
				public Int32? Кол_воМест { get; set; }
				[DataMember]
				public String НомерМеста { get; set; }
				[DataMember]
				public Decimal? Сумма { get; set; }
				[DataMember]
				public String Примечание { get; set; }
		}

		[CollectionDataContract]
		public class СтрТаблКоллекция : Collection<СтрТабл> {}


		static class DataContractMapperCfg
		{
				public static void Initialize()
				{
						AutoMapper.Mapper.Initialize(cfg => {
								cfg.ClearPrefixes();
								cfg.RecognizeDestinationPrefixes(new string[] { "Доставка" });
								cfg.CreateMap<Файл, Core.ДоставкаФайл>();
								cfg.CreateMap<Документ, Core.ДоставкаДокумент>();
								cfg.CreateMap<Отправитель, Core.ДоставкаОтправитель>();
								cfg.CreateMap<Получатель, Core.ДоставкаПолучатель>();
								cfg.CreateMap<ТаблДок, Core.ДоставкаТаблДок>();
								cfg.CreateMap<Параметр, Core.ДоставкаПараметр>();
								cfg.CreateMap<Адрес, Core.ДоставкаАдрес>();
								cfg.CreateMap<Контакт, Core.ДоставкаКонтакт>();
								cfg.CreateMap<СвФЛ, Core.ДоставкаСвФЛ>();
								cfg.CreateMap<СвЮЛ, Core.ДоставкаСвЮЛ>();
								cfg.CreateMap<СтрТабл, Core.ДоставкаСтрТабл>();
								cfg.ClearPrefixes();
								cfg.RecognizePrefixes(new string[] { "Доставка" });
								cfg.CreateMap<Core.ДоставкаФайл, Файл>();
								cfg.CreateMap<Core.ДоставкаДокумент, Документ>();
								cfg.CreateMap<Core.ДоставкаОтправитель, Отправитель>();
								cfg.CreateMap<Core.ДоставкаПолучатель, Получатель>();
								cfg.CreateMap<Core.ДоставкаТаблДок, ТаблДок>();
								cfg.CreateMap<Core.ДоставкаПараметр, Параметр>();
								cfg.CreateMap<Core.ДоставкаАдрес, Адрес>();
								cfg.CreateMap<Core.ДоставкаКонтакт, Контакт>();
								cfg.CreateMap<Core.ДоставкаСвФЛ, СвФЛ>();
								cfg.CreateMap<Core.ДоставкаСвЮЛ, СвЮЛ>();
								cfg.CreateMap<Core.ДоставкаСтрТабл, СтрТабл>();
						});
				}
		}
}

