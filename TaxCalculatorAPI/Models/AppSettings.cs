using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorAPI.Models
{
    public class AppSettings
    {
        public string FixerBaseUrl { get; set; }
        public string FixerApiKey { get; set; }
        public string BaseCurrency { get; set; }

        public Dictionary<string, decimal> TaxRates { get; set; }
    }
}