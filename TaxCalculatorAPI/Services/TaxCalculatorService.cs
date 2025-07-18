using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Services.Interfaces;

namespace TaxCalculatorAPI.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly IFixerService _fixerService;
        private readonly AppSettings _settings;

        public TaxCalculatorService(IFixerService fixerService, AppSettings settings)
        {
            _fixerService = fixerService;
            _settings = settings;
        }
        public async Task<TaxBO> CalculateTax(DateTime invoiceDate, string paymentCurrency, decimal preTaxTotal)
        {
            // Call to get exchange rate
            decimal exchangeRate = await _fixerService.GetExchangeRate(invoiceDate.ToString("yyyy-MM-dd"), _settings.BaseCurrency, paymentCurrency);
            if (!_settings.TaxRates.ContainsKey(paymentCurrency))
            {
                throw new Exception($"Tax rate for currency {paymentCurrency} is not defined.");
            }
            // Main logic to calculate tax
            TaxBO taxBO = new TaxBO
            {
                PreTaxTotalInPaymentCCY = preTaxTotal * exchangeRate,
                ExchangeRate = exchangeRate,
                Currency = paymentCurrency
            };

            taxBO.TaxAmountInPaymentCCY = taxBO.PreTaxTotalInPaymentCCY *  _settings.TaxRates[paymentCurrency];
            
            return taxBO;
        }
    }
}