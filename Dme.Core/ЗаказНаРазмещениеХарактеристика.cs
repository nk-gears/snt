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
    
    public partial class ЗаказНаРазмещениеХарактеристика
    {
        public string Имя { get; set; }
        public string Значение { get; set; }
        public Nullable<int> СтрТабл_Id { get; set; }
        public Nullable<int> ИтогТабл_Id { get; set; }
        public int Характеристика_Id { get; set; }
    
        public virtual ЗаказНаРазмещениеИтогТабл ЗаказНаРазмещениеИтогТабл { get; set; }
        public virtual ЗаказНаРазмещениеСтрТабл ЗаказНаРазмещениеСтрТабл { get; set; }
    }
}
