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
    
    public partial class ЗаказНаРазмещениеТаблДок
    {
        public ЗаказНаРазмещениеТаблДок()
        {
            this.ЗаказНаРазмещениеИтогТабл = new HashSet<ЗаказНаРазмещениеИтогТабл>();
            this.ЗаказНаРазмещениеСтрТабл = new HashSet<ЗаказНаРазмещениеСтрТабл>();
        }
    
        public string Название { get; set; }
        public string Тип { get; set; }
        public int ТаблДок_Id { get; set; }
        public Nullable<int> Документ_Id { get; set; }
    
        public virtual ЗаказНаРазмещениеДокумент ЗаказНаРазмещениеДокумент { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеИтогТабл> ЗаказНаРазмещениеИтогТабл { get; set; }
        public virtual ICollection<ЗаказНаРазмещениеСтрТабл> ЗаказНаРазмещениеСтрТабл { get; set; }
    }
}
