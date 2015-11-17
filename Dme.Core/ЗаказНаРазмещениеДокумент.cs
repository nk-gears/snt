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
    
    public partial class ЗаказНаРазмещениеДокумент
    {
        public ЗаказНаРазмещениеДокумент()
        {
            this.ЗаказНаРазмещениеОснование = new HashSet<ЗаказНаРазмещениеОснование>();
            this.ЗаказНаРазмещениеОтправитель = new HashSet<ЗаказНаРазмещениеОтправитель>();
            this.ЗаказНаРазмещениеПолучатель = new HashSet<ЗаказНаРазмещениеПолучатель>();
            this.ЗаказНаРазмещениеТаблДок = new HashSet<ЗаказНаРазмещениеТаблДок>();
            this.ЗаказНаРазмещениеПараметр = new HashSet<ЗаказНаРазмещениеПараметр>();
        }
    
        public string Дата { get; set; }
        public string Номер { get; set; }
        public int Документ_Id { get; set; }
        public Nullable<int> Файл_Id { get; set; }
        public bool C_Deleted { get; set; }
        public Nullable<System.DateTime> C_DeletedDT { get; set; }
        public Nullable<System.DateTime> C_WmsOrderDT { get; set; }
        public string C_WmsOrderID { get; set; }
        public string C_DeletedUser { get; set; }
    
        public virtual ICollection<ЗаказНаРазмещениеОснование> ЗаказНаРазмещениеОснование { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеОтправитель> ЗаказНаРазмещениеОтправитель { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеПолучатель> ЗаказНаРазмещениеПолучатель { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеТаблДок> ЗаказНаРазмещениеТаблДок { get; set; }
        public virtual ЗаказНаРазмещениеФайл ЗаказНаРазмещениеФайл { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеПараметр> ЗаказНаРазмещениеПараметр { get; set; }
    }
}
