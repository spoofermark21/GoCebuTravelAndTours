using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using GoCebuTravelAndToursMVC.Models;

namespace GoCebuTravelAndToursMVC.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                return View(entities.TourPackages.Where(T => T.EnabledFlag == true && T.BestSellerFlag == true 
                && !string.IsNullOrEmpty(T.CaroImgFileName))
                    .OrderBy(T => T.OrderByDisplay).ToList());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


            return View();
        }

        [ChildActionOnly]
        public PartialViewResult Reviews()
        {
            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                return PartialView(entities.Reviews.Where(T => T.EnabledFlag == true).OrderBy(T => T.Id).ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult ListTourPackages()
        {

            GoCebuDBEntities entities = new GoCebuDBEntities();

            try
            {
                ListTourPackageViewModel listTourPackageViewModel = new ListTourPackageViewModel
                {
                    TourPackageName = null,
                    TourPackages = entities.TourPackages.Where(T => T.EnabledFlag == true && T.GroupBy == "Day")
                    .OrderBy(T => T.OrderByDisplay).ToList()
                };

                return PartialView(listTourPackageViewModel);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


            return PartialView();
        }

    }
}