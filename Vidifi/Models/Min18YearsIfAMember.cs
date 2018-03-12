using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidifi.Models
{
    //custom validation
    public class Min18YearsIfAMember : ValidationAttribute
    {
        //derive class from VadliationAttribute which will give us access to the IsValid method
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //validation logic
            //gives us access to the containing class(customer)
            var customer = (Customer) validationContext.ObjectInstance;
            
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                //Success is a static field in the vadliation result class
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                //return customer message
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            //if age is >= 18 return Validation.Result.Sucess else return new ValidationResult
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}