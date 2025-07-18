using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculatorAPI.Attributes
{
    public class AllowedCurrencyAttribute : ValidationAttribute
    {
        private static readonly HashSet<string> Allowed = new() { "EUR", "USD", "CAD" };

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value is string currency && Allowed.Contains(currency.ToUpper()))
                return ValidationResult.Success;

            return new ValidationResult("Currency must be EUR, USD, or CAD.");
        }
    }
}