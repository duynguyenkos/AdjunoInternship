using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PortIsDifferent : ValidationAttribute
    {
        private readonly string _otherProperty;

        public PortIsDifferent(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherValue = validationContext.ObjectType.GetProperty(_otherProperty).GetValue(validationContext.ObjectInstance, null);

            if ((value != null) && (otherValue != null))
            {
                if (value.ToString().CompareTo(otherValue.ToString()) == 0)
                {
                    return new ValidationResult(ErrorMessage = "Ports cannot be the same");
                }
            }

            return ValidationResult.Success;
        }
    }
}