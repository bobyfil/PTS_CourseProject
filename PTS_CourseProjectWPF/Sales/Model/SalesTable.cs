//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sales.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesTable()
        {
            this.SalesLine = new HashSet<SalesLine>();
        }
    
        public int Id { get; set; }
        public Nullable<int> PaymentAgreement { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime Date { get; set; }
        public string ExternalDocumentId { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual PaymentAgreements PaymentAgreements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesLine> SalesLine { get; set; }
    }
}