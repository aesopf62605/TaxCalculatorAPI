using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Models.DTOs;
using TaxCalculatorAPI.Models.DTOs.UserQuery;
using TaxCalculatorAPI.Services;
using TaxCalculatorAPI.Services.Interfaces;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;

        public TaxCalculatorController(ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }
        // Read
        [HttpGet]
        public async Task<ActionResult<TaxResultDto>> GetTaxCalculator([FromQuery] TaxCalculatorRequestDto query)
        {
            if (query == null)
            {
                return BadRequest("Invalid request data.");
            }

            TaxBO tax = await _taxCalculatorService.CalculateTax(query.InvoiceDate, query.PaymentCurrency, query.PreTaxAmount);

            if (tax == null)
            {
                return NotFound("Tax calculation failed.");
            }
            var product = new TaxResultDto
            {
                PreTaxTotal = tax.PreTaxTotalInPaymentCCY.ToString("N2") + " " + tax.Currency,
                TaxAmount = tax.TaxAmountInPaymentCCY.ToString("N2") + " " + tax.Currency,
                GrantTotal = (tax.PreTaxTotalInPaymentCCY + tax.TaxAmountInPaymentCCY).ToString("N2")  + " "+ tax.Currency, // Total after tax
                ExchangeRate = tax.ExchangeRate,
            };

            return product;

        }
    }
}