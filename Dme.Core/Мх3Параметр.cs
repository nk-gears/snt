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
    
    public partial class Мх3Параметр
    {
        public string Имя { get; set; }
        public string Значение { get; set; }
        public Nullable<int> Участник_Id { get; set; }
        public Nullable<int> Основание_Id { get; set; }
        public Nullable<int> СтрТабл_Id { get; set; }
        public Nullable<int> ИтогТабл_Id { get; set; }
        public Nullable<int> Документ_Id { get; set; }
        public long Параметр_Id { get; set; }
    
        public virtual Мх3Документ Мх3Документ { get; set; }
        public virtual Мх3ИтогТабл Мх3ИтогТабл { get; set; }
        public virtual Мх3Основание Мх3Основание { get; set; }
        public virtual Мх3СтрТабл Мх3СтрТабл { get; set; }
        public virtual Мх3Участник Мх3Участник { get; set; }
    }
}
