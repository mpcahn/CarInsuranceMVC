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
                //Start with a base of $50 / month (using int to count decimals 5000 = $50.00).
                int price = 5000;

                //If the user is under 18, add $100 to the monthly total.
                //If the user is under 25, add $25 to the monthly total.
                //If the user is over 100, add $25 to the monthly total.
                var NowM18 = DateTime.Now.AddYears(-18);
                var NowM25 = DateTime.Now.AddYears(-25);
                var NowM100 = DateTime.Now.AddYears(-100);
                var dob = Convert.ToDateTime(DOB);
                
                if (dob > NowM18) 
                {
                    price += 10000;
                }
                else if (dob > NowM25 || dob < NowM100)
                {
                    price += 2500;
                }                

                //If the car's year is before 2000, add $25 to the monthly total.                
                //If the car's year is after 2015, add $25 to the monthly total.
                var cYear = Convert.ToInt32(carYear);
                if (cYear < 2000 || cYear > 2015)
                {
                    price += 2500;
                }

                //If the car's Make is a Porsche, add $25 to the price.
                if (carMake == "Porsche")
                {
                    price += 2500;

                    //If the car's Make is a Porsche and its model is a 911 Carrera, add an additional $25 to the price.

                    if (carModel == "911 Carrera" || carModel == "Carrera 911")
                    {
                        price += 2500;
                    }
                }

                //Add $10 to the monthly total for every speeding ticket the user has.
                var tickets = Convert.ToInt32(speedingTickets);

                for (var i = tickets; i > 0; i--)
                {
                    price += 1000;
                }

                //If the user has ever had a DUI, add 25 % to the total.
                bool dui = false;

                if (DUI == "y")
                {
                    dui = true;
                    price += Convert.ToInt32(price * .25);
                }

                //If it's full coverage, add 50% to the total.
                if (coverage == "f")
                {
                    price += Convert.ToInt32(price * .5);
                }

                string priceString = (Convert.ToDecimal(price) / 100).ToString("C2");

                using (CarInsuranceEntities db = new CarInsuranceEntities())
                {
                    var quote = new QuoteInfo();
                    quote.FirstName = firstName;
                    quote.LastName = lastName;
                    quote.EmailAddress = emailAddress;
                    quote.DOB = dob;
                    quote.CarYear = cYear;
                    quote.CarMake = carMake;
                    quote.CarModel = carModel;
                    quote.DUI = dui;
                    quote.SpeedingTicket = tickets;
                    quote.coverage = coverage;
                    quote.Quote = price;

                    db.QuoteInfoes.Add(quote);
                    db.SaveChanges();
                }

                ViewBag.price = priceString;
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

        public ActionResult Success()
        {
            return View();
        }
    }
}