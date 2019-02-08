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

            //1 var -- but attributes in the model class have high priority
            //if (string.IsNullOrEmpty(appt.ClientName)) {
            //    ModelState.AddModelError("ClientName", "Please enter your name (from controller)");      //property-level error
            //}
            //if(ModelState.IsValidField("Date")==false && DateTime.Now > appt.Date) {
            //    ModelState.AddModelError("Date", "Please enter a date in the future (from controller)");
            //}
            //if (!appt.TermsAccept)
            //    ModelState.AddModelError("TermsAccept", "You must accept the terms (from controller)");
            //if(ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
            //    && appt.ClientName=="Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday) {
            //    ModelState.AddModelError("", "Joe cannot book appointments on Mondays (from controller)"); //model-level error - the first parameter setup in ""
            //}

            //2 var - whith attribute in the model Appointment +  3 var- whith Java Script

            //statements to store new Apointment in a
            //repository would go here in a real project
            if (ModelState.IsValid)
                return View("Completed", appt);
            else
                return View();
        }

        //3 var - with self model
        public ViewResult MakeBookingWithSelfValidation() {
            return View(new AppointmentsForSelfValidation());
        }

        [HttpPost]
        public ViewResult MakeBookingWithSelfValidation(AppointmentsForSelfValidation appt) {
            if (ModelState.IsValid)
                return View();
            else
                return View();
        }

        //remote validation from the Appointment model attribute [Remote]
        public JsonResult ValidateDate(string Date) {
            DateTime parseDate;

          if(!DateTime.TryParse(Date, out parseDate)) {
                return Json("Please enter a valid date (mm/dd/yyyy)", JsonRequestBehavior.AllowGet);
            } else if(DateTime.Now>parseDate){
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            } else {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}