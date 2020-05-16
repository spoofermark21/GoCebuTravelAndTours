using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class TourGalleryViewModel
    {
        public int Id { get; set; }
        public int TourPackageId { get; set; }
        public string ImgFileName { get; set; }
        public string EnabledFlag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}