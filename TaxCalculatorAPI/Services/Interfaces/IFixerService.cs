using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalculatorAPI.Services.Interfaces
{
    public interface IFixerService
    {
        public Task<decimal> GetExchangeRate(string invoiceDate, string baseCurrency, string targetCurrency);
    }
}