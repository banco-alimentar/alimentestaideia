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
    
    public partial class DonationByReferenceEntity
    {
        public int DonationId { get; set; }
        public string ServiceEntity { get; set; }
        public string ServiceReference { get; set; }
        public Nullable<decimal> ServiceAmount { get; set; }
        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }
        public bool Organization { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public int DonationStatusId { get; set; }
    }
}
