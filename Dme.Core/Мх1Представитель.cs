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
    
    public partial class Мх1Представитель
    {
        public Мх1Представитель()
        {
            this.Мх1СвФЛ = new HashSet<Мх1СвФЛ>();
        }
    
        public string Должность { get; set; }
        public string Роль { get; set; }
        public int Представитель_Id { get; set; }
        public Nullable<int> Отправитель_Id { get; set; }
    
        public virtual Мх1Отправитель Мх1Отправитель { get; set; }
        public virtual ICollection<Мх1СвФЛ> Мх1СвФЛ { get; set; }
    }
}
