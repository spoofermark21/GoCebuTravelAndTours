//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoCebuTravelAndToursMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public int TourPackageId { get; set; }
        public string GuestName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string FacebookAccount { get; set; }
        public Nullable<System.DateTime> BookingStartDate { get; set; }
        public Nullable<System.DateTime> BookingEndDate { get; set; }
        public Nullable<int> TotalLocalGuest { get; set; }
        public Nullable<int> TotalChildGuest { get; set; }
        public Nullable<int> TotalForeignGuest { get; set; }
        public Nullable<decimal> DownPaymentAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> TotalAddOnsAmount { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string SpecialRequest { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentOptions { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
