using ModelValidation.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure {

    public class NoJoeOnMondayAttribute: ValidationAttribute{
        
        public NoJoeOnMondayAttribute() {
            ErrorMessage = "Joe cannot book appointment on Monday";
        }

        public override bool IsValid(object value) {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null) {
                //is absent a model of correctly type or not value for requed properties ClientName and Date
                return true;
            } else {
                return !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}