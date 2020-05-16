using GoCebuTravelAndToursMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GoCebuTravelAndToursMVC.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(InquiryViewModel inquiry)
        {
            GoCebuDBEntities entities = new GoCebuDBEntities();


            if (inquiry.Name != null ||
                inquiry.ContactNumber != null ||
                inquiry.Sender != null ||
                inquiry.Message != null)

            {
                Inquiry inquiryEntity = new Inquiry()
                {
                    Sender = inquiry.Sender,
                    Message = inquiry.Message,
                    Name = inquiry.Name,
                    ContactNumber = inquiry.ContactNumber,
                    CreatedBy = "Guest",
                    CreatedDate = System.DateTime.Now,
                    Status = "Process"
                };

                try
                {
                    entities.Inquiries.Add(inquiryEntity);
                    entities.SaveChanges();

                    string to = "bookings@gocebutour.com";
                    string from = "bookings@gocebutour.com";

                    string Subject = "Go Cebu Travel And Tours Inquiry: " + inquiryEntity.Id + " Name: " + inquiry.Name;
                    string Body = @"Name: " + inquiry.Name
                                    + "<br/>Contact Number: " + inquiry.ContactNumber
                                    + "<br/>Email Address: " + inquiry.Sender
                                    + "<br/>Message: " + inquiry.Message;

                    MailMessage message = new MailMessage(from, to);
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("webmail.gocebutour.com", 587);
                    client.Credentials = new NetworkCredential("bookings@gocebutour.com", "removeforsecurity :P");

                    client.Send(message);

                    var inquiryUpdate = entities.Inquiries.Where(T => T.Id == inquiryEntity.Id).FirstOrDefault();
                    inquiryUpdate.Status = "Sent";

                    entities.SaveChanges();

                    ViewBag.isSent = "Message sent.";


                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    ViewBag.isSent = "Opps, something wen't wrong! :(";

                    var inquiryUpdate = entities.Inquiries.Where(T => T.Id == inquiryEntity.Id).FirstOrDefault();
                    inquiryUpdate.Status = ex.Message;

                }

            }

            ModelState.Clear();

            return View();
        }
    }
}