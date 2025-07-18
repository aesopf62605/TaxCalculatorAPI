using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorAPI.Models.DTOs
{
    public class TaxResultDto
    {
        public required string PreTaxTotal { get; set; }
        public required string TaxAmount { get; set; }
        public required string GrantTotal { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}