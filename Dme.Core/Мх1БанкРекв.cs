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
    
    public partial class Мх1БанкРекв
    {
        public string НаимБанк { get; set; }
        public string БИК { get; set; }
        public string РСчет { get; set; }
        public string КСчет { get; set; }
        public Nullable<int> Отправитель_Id { get; set; }
        public Nullable<int> Получатель_Id { get; set; }
        public int БанкРекв_Id { get; set; }
    
        public virtual Мх1Отправитель Мх1Отправитель { get; set; }
        public virtual Мх1Получатель Мх1Получатель { get; set; }
    }
}
