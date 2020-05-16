using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class TourBookingAddOnsViewModel
    {

        public int Id { get; set; }
        public int TourBookingId { get; set; }
        public int TourPackageAddOnsId { get; set; }
        public string TourPackageAddOnsName { get; set; }
        public int AddOnsPrice { get; set; }
        public bool IsSelectedFlag { get; set; }

    }
}