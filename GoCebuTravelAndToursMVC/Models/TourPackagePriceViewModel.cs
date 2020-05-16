using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class TourPackagePriceViewModel
    {
        public int Id { get; set; }
        public int TourPackageId { get; set; }
        public Nullable<int> Pax { get; set; }
        public Nullable<int> TotalForeignGuest { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<bool> MaxFlag { get; set; }

    }
}