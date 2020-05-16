using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class TourPackageViewModel
    {

        public TourPackage TourPackage { get; set; }

        public int MaxPax { get; set; }

        public List<TourGallery> TourGalleries { get; set; }

        public List<TourPackagePrice> TourPackagePrices { get; set; }

        public List<TourPackageAddOn> TourPackageAddOns { get; set; }

        public BookingViewModel BookingViewModel { get; set; }

        public List<TourBookingAddOnsViewModel> TourBookingAddOns { get; set; }

    }
}