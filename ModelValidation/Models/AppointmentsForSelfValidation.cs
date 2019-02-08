using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models{

    public class AppointmentsForSelfValidation : IValidatableObject {
   
        public string ClientName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool TermsAccept { get; set; }

        //3 var --- self validation in the model class --- BENEFIT: property and model-level in one place
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ClientName)) {
                errors.Add(new ValidationResult("Please enter your name (from self model)"));
            }
            if (DateTime.Now >= Date) {
                errors.Add(new ValidationResult("Please enter a date in the future (from self model)"));
            }
            if(errors.Count==0 && ClientName=="Joe" && Date.DayOfWeek == DayOfWeek.Monday) {
                errors.Add(new ValidationResult("Joe cannot book appointment on Mondays (from self model)"));
            }
            if (!TermsAccept) {
                errors.Add(new ValidationResult("You must accept the terms (from self model)"));
            }
            return errors;
        }
    }
}