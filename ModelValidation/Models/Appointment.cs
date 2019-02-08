using System;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;
using System.Web.Mvc;

namespace ModelValidation.Models{

    //2 var - property and model validation
    [NoJoeOnMonday]
    public class Appointment{

        [Required] //for all application using this model, not only for certain action or view---> high priority before ModelState in controller, but it is also properties level
        [StringLength(10,MinimumLength =3)] //for Java Script validation
        public string ClientName { get; set; }

        //[DataType(DataType.Date)]
        //[Required(ErrorMessage ="Please enter a date")] //buit-in attribute
        //[FutureDate(ErrorMessage ="Please enter a date in the future (from the custom validation attribute)")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true", ErrorMessage ="You must accept the terms (from model)")]  //instead [Required]
        [MustBeTrue(ErrorMessage ="You must accept the terms (from custom validation attribute)")] //custom validation
        public bool TermsAccept { get; set; }

        [Required(ErrorMessage ="Repeate client name")]
        [System.ComponentModel.DataAnnotations.Compare("ClientName")]
        public string EMail { get; set; }
    }
}