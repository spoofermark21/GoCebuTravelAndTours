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
    
    public partial class TourBookingAddOn
    {
        public int Id { get; set; }
        public int TourBookingId { get; set; }
        public int TourPackageAddOnsId { get; set; }
        public Nullable<bool> EnabledFlag { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
