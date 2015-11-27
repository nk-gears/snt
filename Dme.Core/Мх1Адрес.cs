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
    
    public partial class Мх1Адрес
    {
        public Мх1Адрес()
        {
            this.Мх1АдрИно = new HashSet<Мх1АдрИно>();
            this.Мх1АдрРФ = new HashSet<Мх1АдрРФ>();
        }
    
        public string Тип { get; set; }
        public string Наим { get; set; }
        public string АдрТекст { get; set; }
        public int Адрес_Id { get; set; }
        public Nullable<int> Отправитель_Id { get; set; }
        public Nullable<int> Получатель_Id { get; set; }
        public Nullable<int> НормАдр_Id { get; set; }
    
        public virtual Мх1Отправитель Мх1Отправитель { get; set; }
        public virtual Мх1Получатель Мх1Получатель { get; set; }
        public virtual ICollection<Мх1АдрИно> Мх1АдрИно { get; set; }
        public virtual ICollection<Мх1АдрРФ> Мх1АдрРФ { get; set; }
        public virtual НормАдр НормАдр { get; set; }
    }
}
