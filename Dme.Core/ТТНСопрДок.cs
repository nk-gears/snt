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
    
    public partial class ТТНСопрДок
    {
        public int ТТНСопрДок_Id { get; set; }
        public int ТТН_Id { get; set; }
        public string Номер { get; set; }
        public string Дата { get; set; }
        public string Тип { get; set; }
        public Nullable<int> Мх3Документ_Id { get; set; }
        public Nullable<int> ДоставкаДокумент_Id { get; set; }
        public Nullable<int> Кол_воМест { get; set; }
        public string Примечание { get; set; }
        public string ПосылкаНомер { get; set; }
    
        public virtual ТТН ТТН { get; set; }
    }
}
