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
    
    public partial class Мх3Файл
    {
        public Мх3Файл()
        {
            this.Мх3Документ = new HashSet<Мх3Документ>();
        }
    
        public string ИдФайл { get; set; }
        public string ВерсПрог { get; set; }
        public string ИдФорм { get; set; }
        public string ВерсФорм { get; set; }
        public string Сформирован { get; set; }
        public int Файл_Id { get; set; }
        public int C_WfState { get; set; }
        public System.DateTime C_WfLastUpdateDT { get; set; }
        public string C_WfLastUpdateUser { get; set; }
        public bool C_Deleted { get; set; }
        public Nullable<System.DateTime> C_DeleteDT { get; set; }
        public string C_DeletedUser { get; set; }
        public Nullable<int> ЗаказНаОтгрузку_Документ_Id { get; set; }
    
        public virtual ICollection<Мх3Документ> Мх3Документ { get; set; }
    }
}
