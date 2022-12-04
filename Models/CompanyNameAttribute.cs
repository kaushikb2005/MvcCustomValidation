using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace CustomValidation.Models
{
    public class PostalCodeValidationAttribute : ValidationAttribute
    {
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

         
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();

            PropertyInfo CountryProperty = type.GetProperty("Country");
            object CountryPropertyValue = CountryProperty.GetValue(instance);

            PropertyInfo PostalCodeProperty = type.GetProperty("PostalCode");
            object PostalCodePropertyValue = PostalCodeProperty.GetValue(instance);

            //PropertyInfo AddressLine2Property = type.GetProperty("AddressLine2");
            //object AddressLine2PropertyValue = AddressLine1Property.GetValue(instance);

            //PropertyInfo CityProperty = type.GetProperty("City");
            //object CityPropertyValue = CityProperty.GetValue(instance);

            //PropertyInfo PostalCodeProperty = type.GetProperty("PostalCode");
            //object PostalCodePropertyValue = PostalCodeProperty.GetValue(instance);

            //PropertyInfo StateProperty = type.GetProperty("State");
            //object StatePropertyValue = StateProperty.GetValue(instance);

            StringBuilder stringBuilder = new StringBuilder();

          

            if  (Convert.ToString(CountryPropertyValue)?.ToUpper() == "US" || Convert.ToString(CountryPropertyValue)?.ToUpper() == "USA")
            { 
                if(string.IsNullOrEmpty(Convert.ToString(PostalCodePropertyValue)))
                  return new ValidationResult("The PostalCode field is required");
            }
            return null;                   
        }
    }
    public class StateValidationAttribute : ValidationAttribute
    {
       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();

            PropertyInfo CountryProperty = type.GetProperty("Country");
            object CountryPropertyValue = CountryProperty.GetValue(instance);

            PropertyInfo StateProperty = type.GetProperty("State");
            object StatePropertyValue = StateProperty.GetValue(instance);

            if (Convert.ToString(CountryPropertyValue)?.ToUpper() == "US" || Convert.ToString(CountryPropertyValue)?.ToUpper() == "USA")
            {
                if (string.IsNullOrEmpty(Convert.ToString(StatePropertyValue)))
                    return new ValidationResult("The State field is required");
            }
                return null;          
        }

    }
}