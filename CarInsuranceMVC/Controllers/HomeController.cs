using CarInsuranceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(
            string firstName,
            string lastName,
            string emailAddress,
            string DOB,
            string carYear,
            string carMake,
            string carModel,
            string DUI,
            string speedingTickets,
            string coverage
            )
        {
            if (
                string.IsNullOrEmpty(firstName)       ||
                string.IsNullOrEmpty(lastName)        ||
                string.IsNullOrEmpty(emailAddress)    ||
                string.IsNullOrEmpty(DOB)             ||
                string.IsNullOrEmpty(carYear)         ||
                string.IsNullOrEmpty(carMake)         ||
                string.IsNullOrEmpty(carModel)        ||
                string.IsNullOrEmpty(DUI)             ||
                string.IsNullOrEmpty(speedingTickets) ||
                string.IsNullOrEmpty(coverage)
                )
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                //Use the following rules to calculate a quote:
                //Start with a base of $50 / month.
                var quote = 50;

                //If the user is under 25, add $25 to the monthly total.
                

                //If the user is under 18, add $100 to the monthly total.

                //    *
                //If the user is over 100, add $25 to the monthly total.

                //    *
                //If the car's year is before 2000, add $25 to the monthly total.
                //    *
                //If the car's year is after 2015, add $25 to the monthly total.
                //    *
                //If the car's Make is a Porsche, add $25 to the price.
                //    *
                //If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price.
                //    *
                //Add $10 to the monthly total for every speeding ticket the user has.

                //    *
                //If the user has ever had a DUI, add 25 % to the total.

                //    *
                //If it's full coverage, add 50% to the total.



                bool dui = false;
                if (DUI == "y")
                {
                    dui = true;
                }
                                

                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var quote = new QuoteInfo();
                    quote.FirstName = firstName;
                    quote.LastName = lastName;
                    quote.EmailAddress = emailAddress;
                    quote.DOB = Convert.ToDateTime(DOB);
                    quote.CarYear = Convert.ToInt32(carYear);
                    quote.CarMake = carMake;
                    quote.CarModel = carModel;
                    quote.DUI = dui;
                    quote.SpeedingTicket = Convert.ToInt32(speedingTickets);
                    quote.coverage = coverage;
                }

                return View("Success");
            }
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