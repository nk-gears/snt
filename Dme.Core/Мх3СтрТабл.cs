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
    
    public partial class Мх3СтрТабл
    {
        public Мх3СтрТабл()
        {
            this.Мх3Налог = new HashSet<Мх3Налог>();
            this.Мх3Параметр = new HashSet<Мх3Параметр>();
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
        public Nullable<int> C_WmsH2LineId { get; set; }
    
        public virtual ICollection<Мх3Налог> Мх3Налог { get; set; }
        public virtual ICollection<Мх3Параметр> Мх3Параметр { get; set; }
        public virtual Мх3ТаблДок Мх3ТаблДок { get; set; }
    }
}
