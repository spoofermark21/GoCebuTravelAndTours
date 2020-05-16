using GoCebuTravelAndToursMVC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoCebuTravelAndToursMVC.Models
{
    public class BookingViewModel
    {
        public TourPackage TourPackage { get; set; }
        public int Id { get; set; }
        public int TourPackageId { get; set; }
        public string TourPackageName { get; set; }
        public decimal TourPackagePrice { get; set; }
        public decimal TourPackageAddOnsPrice { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Guest Name")]
        public string GuestName { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Display(Name = "Contact number")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Tour date is required")]
        [Display(Name = "Tour Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> BookingStartDate { get; set; }

        [Required(ErrorMessage = "Select tour date")]
        [Display(Name = "End Tour Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BookingEndDate { get; set; }

        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Total Local Amount")]
        public decimal TotalLocalGuestAmount { get; set; }

        [Required(ErrorMessage = "")]
        [Display(Name = "Total Foreign Amount")]
        public decimal TotalForeignAmount { get; set; }

        public decimal TotalAmountEach { get; set; }

        public decimal DownPaymentAmount { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Facebook Account")]
        public string FacebookAccount { get; set; }

        //[Required(ErrorMessage = "Enter number of local guest")]
        [Display(Name = "No. Local Guests")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid value")]
        public Nullable<int> TotalLocalGuest { get; set; }

        //[Required(ErrorMessage = "Enter number of foreign guest")]
        [Display(Name = "No. Foreign Guests")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid value")]
        public Nullable<int> TotalForeignGuest { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        [Display(Name = "No. of Children Guest")]
        [Range(0, int.MaxValue, ErrorMessage = "Enter a valid value")]
        public Nullable<int> TotalChildGuest { get; set; }

        [Required(ErrorMessage = "Pick Up/Drop Off location is required")]
        [Display(Name = "Pick Up/Drop off Location")]
        public string PickUpLocation { get; set; }

        [Display(Name = "Drop Off Location")]
        public string DropOffLocation { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Special Request")]
        public string SpecialRequest { get; set; }

        [Required(ErrorMessage = "Please select payment option.")]
        public string PaymentOptions { get; set; }

        public int TourDurationInHours { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public string PaymentStatus { get; set; }

        public string BookingStatus { get; set; }


    }
}