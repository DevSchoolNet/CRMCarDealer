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
    
    public partial class Prospect
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prospect()
        {
            this.Customers = new HashSet<Customer>();
            this.DriveTests = new HashSet<DriveTest>();
        }
    
        public decimal id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public decimal contact_id { get; set; }
    
        public virtual Contact Contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DriveTest> DriveTests { get; set; }
    }
}
