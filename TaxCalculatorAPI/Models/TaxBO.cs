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

        public override bool Equals(object obj)
        {
            return obj is TaxBO other &&
                   PreTaxTotalInPaymentCCY == other.PreTaxTotalInPaymentCCY &&
                   TaxAmountInPaymentCCY == other.TaxAmountInPaymentCCY &&
                   GrantTotalInPaymentCCY == other.GrantTotalInPaymentCCY &&
                   ExchangeRate == other.ExchangeRate &&
                   Currency == other.Currency;
        }
    }
}