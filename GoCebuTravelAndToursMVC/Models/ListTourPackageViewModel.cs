using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class ListTourPackageViewModel
    { 

        [Display(Name = "Search Tour Package")]
        public String TourPackageName { get; set; }

        public List<TourPackage> TourPackages { get; set; }
    }
}