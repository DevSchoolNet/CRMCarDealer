//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public decimal id { get; set; }
        public decimal customer_id { get; set; }
        public decimal specialoffer_id { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}