using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var quotes = db.QuoteInfoes;

                var quoteVms = new List<QuoteVM>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVM();
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;

                    string quoteString = (Convert.ToDecimal(quote.Quote) / 100).ToString("C2");

                    quoteVm.Quote = quoteString;
                    quoteVms.Add(quoteVm);
                }
                return View(quoteVms);
            }
               
        }
    }
}