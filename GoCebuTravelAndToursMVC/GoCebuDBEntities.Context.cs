﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoCebuDBEntities : DbContext
    {
        public GoCebuDBEntities()
            : base("name=GoCebuDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<TourBookingAddOn> TourBookingAddOns { get; set; }
        public virtual DbSet<TourGallery> TourGalleries { get; set; }
        public virtual DbSet<TourPackageAddOn> TourPackageAddOns { get; set; }
        public virtual DbSet<TourPackagePrice> TourPackagePrices { get; set; }
        public virtual DbSet<TourPackage> TourPackages { get; set; }
        public virtual DbSet<Inquiry> Inquiries { get; set; }
    }
}
