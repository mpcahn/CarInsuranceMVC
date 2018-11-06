using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {
        //Use the following rules to calculate a quote:

        //Start with a base of $50 / month.

        //If the user is under 25, add $25 to the monthly total.

        //If the user is under 18, add $100 to the monthly total.

        //If the user is over 100, add $25 to the monthly total.

        //If the car's year is before 2000, add $25 to the monthly total.

        //If the car's year is after 2015, add $25 to the monthly total.

        //If the car's Make is a Porsche, add $25 to the price.

        //If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price.

        //Add $10 to the monthly total for every speeding ticket the user has.

        //If the user has ever had a DUI, add 25% to the total.

        //If it's full coverage, add 50% to the total.


        //There must also be an Admin view for a site administrator. This page must:

        //Show all quotes issued, along with the user's first name, last name, and email address.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}