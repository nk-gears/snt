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
    
    public partial class Route
    {
        public Route()
        {
            this.Lading = new HashSet<Lading>();
        }
    
        public short RouteID { get; set; }
        public Nullable<System.DateTime> LoadDT { get; set; }
        public Nullable<int> CarrierID { get; set; }
        public string Note { get; set; }
        public string Gate { get; set; }
        public int Priority { get; set; }
    
        public virtual Carrier Carrier { get; set; }
        public virtual ICollection<Lading> Lading { get; set; }
    }
}