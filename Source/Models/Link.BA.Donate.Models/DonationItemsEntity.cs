//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Link.BA.Donate.Models
{
    using System;
    
    public partial class DonationItemsEntity
    {
        public int DonationItemId { get; set; }
        public int DonationItemQuantity { get; set; }
        public Nullable<int> DonationId { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal Cost { get; set; }
        public Nullable<decimal> ProductCatalogueQuantity { get; set; }
        public string IconUrl { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    }
}
