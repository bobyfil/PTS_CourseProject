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
    
    public partial class SalesLine
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
    
        public virtual Items Items { get; set; }
        public virtual SalesTable SalesTable { get; set; }
    }
}