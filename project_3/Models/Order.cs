//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id_order { get; set; }
        public Nullable<int> id_product { get; set; }
        public Nullable<int> id_employee { get; set; }
        public Nullable<int> id_customer { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> time { get; set; }
        public string vat { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
    }
}