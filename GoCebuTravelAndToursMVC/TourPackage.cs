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
    
    public partial class TourPackage
    {
        public int Id { get; set; }
        public string TourPackageName { get; set; }
        public string TourPackageDescription { get; set; }
        public string TourItineraryDetails { get; set; }
        public string AdditionalDetails { get; set; }
        public string InclusionDetails { get; set; }
        public string ImgFileName { get; set; }
        public Nullable<bool> IsSharedFlag { get; set; }
        public Nullable<bool> IsCustomizeFlag { get; set; }
        public Nullable<bool> BestSellerFlag { get; set; }
        public Nullable<decimal> ForeignPrice { get; set; }
        public Nullable<decimal> ExtendedPaxPrice { get; set; }
        public Nullable<int> OrderByDisplay { get; set; }
        public Nullable<bool> EnabledFlag { get; set; }
        public string GroupBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<int> TourDurationInHours { get; set; }
        public string CaroImgFileName { get; set; }
    }
}