using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class SimilarOrLaterThanShipDateAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;

        public SimilarOrLaterThanShipDateAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherValue = validationContext.ObjectType.GetProperty(_otherProperty).GetValue(validationContext.ObjectInstance, null);

            if ((value != null) && (otherValue != null))
            {
                if (value.ToString().CompareTo(otherValue.ToString()) < 0)
                {
                    return new ValidationResult(ErrorMessage = "Cannot be before Ship Date");
                }
            }

            return ValidationResult.Success;
        }
    }
}