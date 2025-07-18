using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorAPI.Models;

namespace TaxCalculatorAPI.Services.Interfaces
{
    public interface ITaxCalculatorService
    {
        public Task<TaxBO> CalculateTax(DateTime invoiceDate, string paymentCurrency, decimal preTaxTotal);
    }
}