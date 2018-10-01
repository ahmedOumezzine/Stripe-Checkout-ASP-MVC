using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StripeCheckoutDemo.Controllers
{
    public class StripeCheckoutController : Controller
    {
        // GET: StripeCheckout
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Charge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            if(charge.Paid)
            {
                return View();
            }
            else
            {
                return View("error");
            }
        }
    }
}