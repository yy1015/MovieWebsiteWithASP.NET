using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearIsMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.unKnown && customer.MemberShipTypeId == MemberShipType.PayAsYouGo)

                return ValidationResult.Success;
            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthday is required");
            }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customers should be over 18");




        }
    }
}