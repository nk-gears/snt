//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dme.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЗаказНаОтгрузкуСтрТабл
    {
        public ЗаказНаОтгрузкуСтрТабл()
        {
            this.ЗаказНаОтгрузкуНалог = new HashSet<ЗаказНаОтгрузкуНалог>();
            this.ЗаказНаОтгрузкуПараметр = new HashSet<ЗаказНаОтгрузкуПараметр>();
        }
    
        public string ПорНомер { get; set; }
        public string Наим { get; set; }
        public Nullable<int> Кол_во { get; set; }
        public string ЕдИзм { get; set; }
        public string ОКЕИ { get; set; }
        public Nullable<decimal> Цена { get; set; }
        public Nullable<decimal> СуммаБезНал { get; set; }
        public Nullable<decimal> Сумма { get; set; }
        public string Примечание { get; set; }
        public string Описание { get; set; }
        public string Ид { get; set; }
        public int СтрТабл_Id { get; set; }
        public Nullable<int> Таблица_Id { get; set; }
    
        public virtual ICollection<ЗаказНаОтгрузкуНалог> ЗаказНаОтгрузкуНалог { get; set; }
        public virtual ICollection<ЗаказНаОтгрузкуПараметр> ЗаказНаОтгрузкуПараметр { get; set; }
        public virtual ЗаказНаОтгрузкуТаблица ЗаказНаОтгрузкуТаблица { get; set; }
    }
}
