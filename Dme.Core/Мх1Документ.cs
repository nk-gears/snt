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
    
    public partial class Мх1Документ
    {
        public Мх1Документ()
        {
            this.Мх1Основание = new HashSet<Мх1Основание>();
            this.Мх1Отправитель = new HashSet<Мх1Отправитель>();
            this.Мх1Получатель = new HashSet<Мх1Получатель>();
            this.Мх1ТаблДок = new HashSet<Мх1ТаблДок>();
            this.Мх1Параметр = new HashSet<Мх1Параметр>();
        }
    
        public string Дата { get; set; }
        public string Номер { get; set; }
        public int Документ_Id { get; set; }
        public Nullable<int> Файл_Id { get; set; }
    
        public virtual ICollection<Мх1Основание> Мх1Основание { get; set; }
        public virtual ICollection<Мх1Отправитель> Мх1Отправитель { get; set; }
        public virtual ICollection<Мх1Получатель> Мх1Получатель { get; set; }
        public virtual ICollection<Мх1ТаблДок> Мх1ТаблДок { get; set; }
        public virtual Мх1Файл Мх1Файл { get; set; }
        public virtual ICollection<Мх1Параметр> Мх1Параметр { get; set; }
    }
}
