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
    
    public partial class ДоставкаСтрТабл
    {
        public Nullable<int> ПорНомер { get; set; }
        public string Название { get; set; }
        public Nullable<int> Кол_воМест { get; set; }
        public string НомерМеста { get; set; }
        public Nullable<decimal> Сумма { get; set; }
        public string Примечание { get; set; }
        public Nullable<int> ТаблДок_Id { get; set; }
        public int СтрТабл_Id { get; set; }
    
        public virtual ДоставкаТаблДок ДоставкаТаблДок { get; set; }
    }
}
