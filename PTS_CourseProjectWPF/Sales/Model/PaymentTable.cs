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
    
    public partial class PaymentTable
    {
        public int Id { get; set; }
        public int PaymentAgreement { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ExternalDocumentId { get; set; }
    
        public virtual PaymentAgreements PaymentAgreements { get; set; }
    }
}
