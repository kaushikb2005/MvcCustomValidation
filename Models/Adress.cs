using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomValidation.Models
{
    public class Adress
    {
        [Required]
       
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

       
        [Required]
        public string City { get; set; }

        [PostalCodeValidationAttribute]
        public string PostalCode { get; set; }

        [StateValidationAttribute]
        public string State { get; set; }

        [Required]
        
        public string Country { get; set; }
    }
}