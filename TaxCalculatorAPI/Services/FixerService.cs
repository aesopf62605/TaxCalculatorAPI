using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Services.Interfaces;

namespace TaxCalculatorAPI.Services
{
    public class FixerService : IFixerService
    {
        private readonly AppSettings _settings;

        public FixerService(AppSettings settings)
        {
            _settings = settings;
        }
        public async Task<decimal> GetExchangeRate(string invoiceDate, string baseCurrency, string targetCurrency)
        {
            var client = new RestClient(_settings.FixerBaseUrl);
            var request = new RestRequest(invoiceDate, Method.Get);
            request.AddParameter("access_key", _settings.FixerApiKey);
            request.AddParameter("base", baseCurrency);
            request.AddParameter("symbols", targetCurrency);

            var response = await client.ExecuteAsync<FixerResponse>(request);
            Console.WriteLine(response.Content);

            if (response.IsSuccessful && response.Data != null && response.Data.Rates.ContainsKey(targetCurrency))
            {
                return response.Data.Rates[targetCurrency];
            }
            else
            {
                throw new Exception("Failed to retrieve exchange rate.");
            }
        }
    }

    class FixerResponse
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}