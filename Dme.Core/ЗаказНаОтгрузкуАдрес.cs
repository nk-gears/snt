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
    
    public partial class ЗаказНаОтгрузкуАдрес
    {
        public ЗаказНаОтгрузкуАдрес()
        {
            this.ЗаказНаОтгрузкуАдрИно = new HashSet<ЗаказНаОтгрузкуАдрИно>();
            this.ЗаказНаОтгрузкуАдрРФ = new HashSet<ЗаказНаОтгрузкуАдрРФ>();
        }
    
        public string Тип { get; set; }
        public string Наим { get; set; }
        public int Адрес_Id { get; set; }
        public Nullable<int> Участник_Id { get; set; }
        public string Маршрут_Id { get; set; }
        public Nullable<int> НормАдр_Id { get; set; }
    
        public virtual ICollection<ЗаказНаОтгрузкуАдрИно> ЗаказНаОтгрузкуАдрИно { get; set; }
        public virtual ICollection<ЗаказНаОтгрузкуАдрРФ> ЗаказНаОтгрузкуАдрРФ { get; set; }
        public virtual ЗаказНаОтгрузкуУчастник ЗаказНаОтгрузкуУчастник { get; set; }
        public virtual НормАдр НормАдр { get; set; }
    }
}
