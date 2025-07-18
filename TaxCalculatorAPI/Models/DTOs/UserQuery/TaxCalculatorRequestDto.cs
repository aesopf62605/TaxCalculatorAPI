using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorAPI.Attributes;

namespace TaxCalculatorAPI.Models.DTOs.UserQuery
{
    public class TaxCalculatorRequestDto
    {
        [Required(ErrorMessage = "InvoiceDate is required")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "PreTaxAmount is required")]
        public decimal PreTaxAmount { get; set; }
        [Required(ErrorMessage = "PaymentCurrency is required")]
        [AllowedCurrencyAttribute(ErrorMessage = "Currency must be EUR, USD, or CAD.")]
        public required string PaymentCurrency { get; set; }
    }
}