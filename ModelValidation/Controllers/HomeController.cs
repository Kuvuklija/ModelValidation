using System.Web.Mvc;
using ModelValidation.Models;
using System;

namespace ModelValidation.Controllers{

    public class HomeController : Controller{
        
        public ViewResult MakeBooking() {
            return View(new Appointment());
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt) {

            //1 var
            if (string.IsNullOrEmpty(appt.ClientName)) {
                ModelState.AddModelError("ClientName", "Please enter your name");
            }
            if(ModelState.IsValidField("Date") && DateTime.Now > appt.Date) {
                ModelState.AddModelError("Date", "Please enter a date in the future");
            }
            if (!appt.TermsAccept)
                ModelState.AddModelError("TermsAccept", "You must accept the terms");

            //statements to store new Apointment in a
            //repository would go here in a real project
            if (ModelState.IsValid)
                return View("Completed", appt);
            else
                return View();
        }
    }
}