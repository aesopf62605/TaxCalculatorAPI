using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorAPI.Models
{
    public class TaxBO
    {
        public decimal PreTaxTotalInPaymentCCY { get; set; }
        public decimal TaxAmountInPaymentCCY { get; set; }
        public decimal GrantTotalInPaymentCCY { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Currency { get; set; }
    }
}