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
    
    public partial class Мх1СвЮЛ
    {
        public string Название { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string ОКДП { get; set; }
        public string ОКПО { get; set; }
        public Nullable<int> Отправитель_Id { get; set; }
        public Nullable<int> Получатель_Id { get; set; }
        public int СвЮЛ_Id { get; set; }
    
        public virtual Мх1Отправитель Мх1Отправитель { get; set; }
        public virtual Мх1Получатель Мх1Получатель { get; set; }
    }
}
