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
    
    public partial class Мх3ИтогТабл
    {
        public Мх3ИтогТабл()
        {
            this.Мх3Налог = new HashSet<Мх3Налог>();
            this.Мх3Параметр = new HashSet<Мх3Параметр>();
        }
    
        public string Тип { get; set; }
        public Nullable<int> Кол_во { get; set; }
        public Nullable<decimal> Нетто { get; set; }
        public Nullable<decimal> Брутто { get; set; }
        public Nullable<decimal> СуммаБезНал { get; set; }
        public Nullable<decimal> Сумма { get; set; }
        public string Примечание { get; set; }
        public int ИтогТабл_Id { get; set; }
        public Nullable<int> Таблица_Id { get; set; }
    
        public virtual ICollection<Мх3Налог> Мх3Налог { get; set; }
        public virtual ICollection<Мх3Параметр> Мх3Параметр { get; set; }
        public virtual Мх3ТаблДок Мх3ТаблДок { get; set; }
    }
}
