using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class TourPackageAddOnsViewModel
    {
        public int Id { get; set; }
        public int TourPackageId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<bool> EnabledFlag { get; set; }
        public bool IsSelected { get; set; }

    }
}