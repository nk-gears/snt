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
    
    public partial class ДоставкаОтправитель
    {
        public ДоставкаОтправитель()
        {
            this.ДоставкаАдрес = new HashSet<ДоставкаАдрес>();
            this.ДоставкаКонтакт = new HashSet<ДоставкаКонтакт>();
            this.ДоставкаСвФЛ = new HashSet<ДоставкаСвФЛ>();
            this.ДоставкаСвЮЛ = new HashSet<ДоставкаСвЮЛ>();
            this.ДоставкаПараметр = new HashSet<ДоставкаПараметр>();
        }
    
        public string Название { get; set; }
        public Nullable<int> Документ_Id { get; set; }
        public int Отправитель_Id { get; set; }
    
        public virtual ICollection<ДоставкаАдрес> ДоставкаАдрес { get; set; }
        public virtual ДоставкаДокумент ДоставкаДокумент { get; set; }
        public virtual ICollection<ДоставкаКонтакт> ДоставкаКонтакт { get; set; }
        public virtual ICollection<ДоставкаСвФЛ> ДоставкаСвФЛ { get; set; }
        public virtual ICollection<ДоставкаСвЮЛ> ДоставкаСвЮЛ { get; set; }
        public virtual ICollection<ДоставкаПараметр> ДоставкаПараметр { get; set; }
    }
}
