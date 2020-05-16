
using GoCebuTravelAndToursMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace GoCebuTravelAndToursMVC.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ListTourPackages(string groupBy)
        {
            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                if (groupBy != null)
                {
                    var results = entities.TourPackages
                        .Where(T => T.GroupBy.Contains(groupBy))
                        .Where(T => T.EnabledFlag == true)
                        .OrderBy(T => T.OrderByDisplay)
                        .OrderBy(T => T.Id)
                        .ToList();

                    if (groupBy == "all")
                    {
                        results = entities.TourPackages.Where(T => T.EnabledFlag == true).OrderBy(T => T.OrderByDisplay).ToList();
                    }

                    ViewBag.groupBy = groupBy;

                    if (results.Count == 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return View(results);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: TourPackage Displays Data in Tour/TourPackage
        public ActionResult TourPackage(int? id, string groupBy)
        {

            Session["BOOKING"] = null;

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            GoCebuDBEntities entities = new GoCebuDBEntities();
            try
            {
                ViewBag.groupBy = groupBy;

                TourPackageViewModel tourPackage = new TourPackageViewModel()
                {
                    TourPackage = entities.TourPackages.Find(id),
                    TourPackagePrices = entities.TourPackagePrices.Where(T => T.TourPackageId == id && T.EnabledFlag == true)   
                                        .OrderBy(T => T.Pax).ToList(),
                    TourGalleries = entities.TourGalleries.Where(T => T.TourPackageId == id).ToList()
                };

                var dateTime = DateTime.Now;

                tourPackage.BookingViewModel = new BookingViewModel()
                {
                    TourPackageId = tourPackage.TourPackage.Id,
                    TourPackageName = tourPackage.TourPackage.TourPackageName,
                    TourDurationInHours = (int)tourPackage.TourPackage.TourDurationInHours
                };

                //get max pax number
                tourPackage.MaxPax = (int)entities.TourPackagePrices
                    .Where(T => T.TourPackageId == tourPackage.BookingViewModel.TourPackageId)
                    .Max(T => T.Pax);


                tourPackage.TourPackageAddOns = entities.TourPackageAddOns.Where(T => T.TourPackageId == id).ToList();


                if (tourPackage.TourPackage == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(tourPackage);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult TourPackage(TourPackageViewModel tourPackage, int[] tourPackageAddOnsIds)
        {

            if (tourPackage.BookingViewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                if (Session["BOOKING"] == null)
                {
                    var tourPackageDetails = entities.TourPackages
                        .Where(T => T.Id == tourPackage.BookingViewModel.TourPackageId)
                        .FirstOrDefault();

                    tourPackage.TourPackage = new TourPackage() { };
                    
                    //get base tourpackage price
                    var tourPackagePrice = entities.TourPackagePrices
                                                    .Where(T => T.TourPackageId == tourPackage.BookingViewModel.TourPackageId
                                                        && T.Pax == (tourPackage.BookingViewModel.TotalLocalGuest + 
                                                                        tourPackage.BookingViewModel.TotalForeignGuest))
                                                    .FirstOrDefault();

                    if (tourPackagePrice != null)
                    {
                        //get pax amount by number of guest
                        tourPackage.BookingViewModel.TourPackagePrice = (decimal)(tourPackagePrice.Amount * tourPackagePrice.Pax);
                    }
                    else
                    {
                        //get max pax number
                        var maxPax = entities.TourPackagePrices
                            .Where(T => T.TourPackageId == tourPackage.BookingViewModel.TourPackageId)
                            .Max(T => T.Pax);

                        //get maximum pax amount
                        tourPackagePrice = entities.TourPackagePrices
                        .Where(T => T.TourPackageId == tourPackage.BookingViewModel.TourPackageId
                        && T.Pax == maxPax).FirstOrDefault();

                    }

                    tourPackage.BookingViewModel.TotalAmountEach = (decimal)tourPackagePrice.Amount;

                    //Local amount base price
                    tourPackage.BookingViewModel.TotalLocalGuestAmount = tourPackage.BookingViewModel.TotalAmountEach * (int)tourPackage.BookingViewModel.TotalLocalGuest;

                    //Foreign amount base price
                    tourPackage.BookingViewModel.TotalForeignAmount = tourPackage.BookingViewModel.TotalAmountEach * (int)tourPackage.BookingViewModel.TotalForeignGuest;

                    tourPackage.BookingViewModel.TotalAmount = tourPackage.BookingViewModel.TotalLocalGuestAmount
                        + tourPackage.BookingViewModel.TotalForeignAmount;

                    //set end date
                    DateTime endDate = new DateTime();
                    endDate = (DateTime)tourPackage.BookingViewModel.BookingStartDate;

                    if(tourPackage.BookingViewModel.TourDurationInHours / 24 > 1)
                        tourPackage.BookingViewModel.BookingEndDate = endDate.AddDays(((double)tourPackage.BookingViewModel.TourDurationInHours / 24) - 1);
                    else
                        tourPackage.BookingViewModel.BookingEndDate = endDate.AddDays(((double)tourPackage.BookingViewModel.TourDurationInHours / 24));

                    Booking booking = new Booking
                    {
                        GuestName = tourPackage.BookingViewModel.GuestName,
                        ContactNumber = tourPackage.BookingViewModel.ContactNumber,
                        EmailAddress = tourPackage.BookingViewModel.EmailAddress,
                        TourPackageId = tourPackage.BookingViewModel.TourPackageId,
                        TotalLocalGuest = tourPackage.BookingViewModel.TotalLocalGuest,
                        TotalChildGuest = tourPackage.BookingViewModel.TotalChildGuest,
                        TotalForeignGuest = tourPackage.BookingViewModel.TotalForeignGuest,
                        PickUpLocation = tourPackage.BookingViewModel.PickUpLocation,
                        BookingStartDate = tourPackage.BookingViewModel.BookingStartDate,
                        BookingEndDate = tourPackage.BookingViewModel.BookingEndDate,
                        TotalAmount = tourPackage.BookingViewModel.TotalAmount,
                        SpecialRequest = tourPackage.BookingViewModel.SpecialRequest,
                        BookingStatus = "ENTERED",
                        PaymentStatus = "PENDING",
                        IsConfirmed = false,
                        CreatedDate = System.DateTime.Now,
                        CreatedBy = "System"
                    };

                    if (tourPackageAddOnsIds != null)
                    {
                        var AddOns = new List<TourBookingAddOnsViewModel>();

                        foreach (int id in tourPackageAddOnsIds)
                        {
                            Console.WriteLine(id);

                            var addOn = entities.TourPackageAddOns.Find(id);

                            AddOns.Add(new TourBookingAddOnsViewModel()
                            {
                                TourPackageAddOnsId = id,
                                TourPackageAddOnsName = addOn.Name,
                                AddOnsPrice = (int)addOn.Price
                            });

                            entities.TourBookingAddOns.Add(new TourBookingAddOn
                            {
                                TourBookingId = booking.Id,
                                TourPackageAddOnsId = id,
                            });

                            entities.SaveChanges();

                        };

                        tourPackage.TourBookingAddOns = AddOns;
                        tourPackage.BookingViewModel.TourPackageAddOnsPrice = tourPackage.TourBookingAddOns.Sum(T => T.AddOnsPrice);

                    }

                    if (tourPackage.TourBookingAddOns != null)
                        booking.TotalAddOnsAmount = tourPackage.BookingViewModel.TourPackageAddOnsPrice;

                    //Downpayment 25% of the total amount
                    booking.DownPaymentAmount = (decimal)(booking.TotalAmount * (decimal)0.25);
                    tourPackage.BookingViewModel.DownPaymentAmount = (decimal)booking.DownPaymentAmount;

                    entities.Bookings.Add(booking);
                    entities.SaveChanges();

                    tourPackage.BookingViewModel.Id = booking.Id;

                    tourPackage.BookingViewModel.BookingStatus = "ENTERED";
                    tourPackage.BookingViewModel.PaymentStatus = "PENDING";
                    tourPackage.BookingViewModel.IsConfirmed = false;
                    tourPackage.BookingViewModel.CreatedDate = System.DateTime.Now;

                    Console.WriteLine(tourPackage.BookingViewModel.BookingEndDate);

                    Session["BOOKING"] = tourPackage;

                    Console.WriteLine(Session["BOOKING"]);

                    return View("Confirmation", tourPackage);
                }
                else
                    return View("Confirmation", Session["BOOKING"] as TourPackageViewModel);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Confirmation(TourPackageViewModel tourPackage)
        {
            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                var book = entities.Bookings.First(T => T.Id == tourPackage.BookingViewModel.Id);

                book.BookingStatus = "CONFIRMED";
                book.LastUpdatedDate = System.DateTime.Now;
                book.PaymentOptions = tourPackage.BookingViewModel.PaymentOptions;

                entities.SaveChanges();

                tourPackage.BookingViewModel.PaymentOptions = book.PaymentOptions;

                var addOnsSession = Session["BOOKING"] as TourPackageViewModel;

                string selectedAddOns = String.Empty;

                if (addOnsSession.TourBookingAddOns != null)
                {
                    selectedAddOns = "Selected add ons: <br/>";

                    foreach (TourBookingAddOnsViewModel addons in addOnsSession.TourBookingAddOns)
                    {
                        selectedAddOns = selectedAddOns + " " + addons.TourPackageAddOnsName + " <br/>";
                    }

                    selectedAddOns = selectedAddOns + "<br/>";
                }

                string paymentOptions = "";

                if (tourPackage.BookingViewModel.PaymentOptions == "banktransfer")
                {
                    paymentOptions = @"*Bank Deposit *<br/>
                    Bank: Security Bank<br/>
                    Account No.: 0000025003701<br/>
                    Account Name: GoCebu Travel and Tours<br/>
                    Swift Code: SETCPHMM<br/><br/>

                    Bank: Bank of Philippine Island (BPI)<br/>
                    Account No.: 9096265259<br/>
                    Account Name: Marvin Sibi<br/>
                    Swift Code: BOPIPHMM<br/><br/>

                    Bank: EastWest Bank<br/>
                    Account No.: 200011706467<br/>
                    Account Name: Marvin Sibi<br/>
                    Swift Code: EWBCPHMM<br/><br/>

                    * Swift code use for international bank to bank transfer. <br/><br/>
                    ";
                }
                else if(tourPackage.BookingViewModel.PaymentOptions == "moneytransfer")
                {
                    paymentOptions = @"* Money Transfer *<br/>
                    For money transfer via Cebuana Lhuillier, MLhuillier, Western Union or any money transfer please use the following details: <br/><br/>

                    Name: Marvin Sibi<br/>
                    Mobile No.: +639173056635<br/>
                    Address: No. 45 Zone Camanse, Plaridel St., Brgy. Paknaan, Mandaue City, Cebu, Ph 6014<br/><br/>";

                } 
                else if(tourPackage.BookingViewModel.PaymentOptions == "creditcard")
                {
                    paymentOptions = @"* Credit Card via PayPal with 6% transaction fee *<br />
                                    Step 1: Go Cebu will send an electronic invoice to your provided email.<br />
                                    Step 2: Click on 'Pay now' in the email or invoice you've received.<br />
                                    Step 3: Enter your credit or debit card details.<br />
                                    Step 4: Confirm the payment.<br />";
                }

                string Subject = "Go Cebu Travel And Tours : " + tourPackage.BookingViewModel.TourPackageName + ": Reference # " + book.Id.ToString().PadLeft(10, '0');
                string Body =
                    "<h1> Thank you for booking with us, " + book.GuestName + "! </h1> <br/>" +
                    "<h3>Booking Reference ID: " + book.Id.ToString().PadLeft(10, '0') + "</h3><br/>" +
                    "Tour Package: " + tourPackage.BookingViewModel.TourPackageName + "<br/>" +
                    "Name: " + book.GuestName + "<br/>" +
                    "Contact Number: " + book.ContactNumber + "<br/>" +
                    "Total Local Guest: " + book.TotalLocalGuest + "<br/>" +
                    "Total Foreign Guest: " + book.TotalForeignGuest + "<br/>" +
                    "Total Children: " + book.TotalChildGuest + "<br/>" +
                    "Tour Date: " + @Convert.ToDateTime(book.BookingStartDate).ToString("MM/dd/yyyy") + "<br/>" +
                    "Pick Up Location: " + book.PickUpLocation + "<br/>" +
                    "Special Request: " + book.SpecialRequest +"<br/>" +
                    "Total Amount: <span>&#8369;</span>" + @String.Format("{0:n}", book.TotalAmount)  + "<br/>" +
                    "Total Required Downpayment: <span>&#8369;</span>" + @String.Format("{0:n}", book.DownPaymentAmount)  + "<br/><br/>" +

                    selectedAddOns

                    +

                    @"To confirm your booking, we will require 25% minimum downpayment of the total amount using the following payment methods:<br/>
                    <br/>"
                    
                    + paymentOptions +

                    @"Note<br/>
                    * Once paid, please send us a picture or screenshot of the payment receipt or confirmation so we can verify on our end.<br/>
                    * Remaining balance will be collected on the day of the tour by the authorize driver or tour guide.<br/>
                    * Strictly no down payment, no confirmation of booking.<br/><br/>" +

                    @"

                    <h3>TERMS AND CONDITIONS</h3>
                    <br/>
                    Attached https://drive.google.com/file/d/1vkeC-tlyYtArG4aZ621ZB2zzNB6_nZ15/view 
                   <br/><br/>

                    'We Travel As One' <br/><br/>" +
                    "</div>" +
                    @"<div>
                    
                    GOCEBU TRAVEL AND TOURS<br/>
                    No. 45 Zone Camanse, Plaridel Street<br/>
                    Brgy. Paknaan, Mandaue City, Cebu, Ph 6014<br/>
                    Globe : +63 917 305 6635 <br/>
                    Smart : +63 939 607 1412<br/>
                    Email : bookings@gocebutour.com<br/>
                    Facebook Page : www.facebook.com/gocebutravelandtours<br/>
                    Website: www.gocebutour.com <br/>

            

                     </div>
                        ";

                string Sender = "bookings@gocebutour.com";
                string To = book.EmailAddress;

                MailMessage mail = new MailMessage();

                mail.To.Add(To);
                mail.From = new MailAddress(Sender);
                mail.Bcc.Add("gocebutravelandtours@gmail.com");
                mail.CC.Add("bookings@gocebutour.com");

                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                var client = new SmtpClient("webmail.gocebutour.com", 587)
                {
                    Credentials = new NetworkCredential("bookings@gocebutour.com", "removeforsecurity :P :P!")
                };

                client.Send(mail);

                Console.WriteLine("Email sent succesfully.");

                Session["MsgSentFlag"] = "sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }

            return View("Complete", tourPackage);
        }

        public ActionResult ListTourPackage()
        {
            return View();
        }


    }
}