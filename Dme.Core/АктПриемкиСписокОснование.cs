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
    
    public partial class АктПриемкиСписокОснование
    {
        public АктПриемкиСписокОснование()
        {
            this.АктПриемкиОснование = new HashSet<АктПриемкиОснование>();
        }
    
        public int СписокОснование_Id { get; set; }
        public Nullable<int> Документ_Id { get; set; }
    
        public virtual АктПриемкиДокумент АктПриемкиДокумент { get; set; }
        public virtual ICollection<АктПриемкиОснование> АктПриемкиОснование { get; set; }
    }
}
