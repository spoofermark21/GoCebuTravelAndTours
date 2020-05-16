using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GoCebuTravelAndToursMVC.Models
{
    public class InquiryViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Your email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your contact number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }


        public string Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public List<TourPackage> TourPackages { get; set; }
       
    }
}