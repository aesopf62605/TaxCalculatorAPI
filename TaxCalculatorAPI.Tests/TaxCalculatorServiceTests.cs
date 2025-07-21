using System.Reflection.Metadata.Ecma335;
using TaxCalculatorAPI.Models;
using TaxCalculatorAPI.Services.Interfaces;
using Unity;

namespace TaxCalculatorAPI.Tests;

[TestFixture]
public class TaxCalculatorServiceTests : BaseFixture
{
    private ITaxCalculatorService _taxCalculatorService;

    [SetUp]
    public void Setup()
    {
        _taxCalculatorService = Container.Resolve<ITaxCalculatorService>();
    }

    public static IEnumerable<TestCaseData> testCases =>
    new[]
    {
        new TestCaseData(new DateTime(2020, 8,5), "USD", 123.45m).Returns(new TaxBO { PreTaxTotalInPaymentCCY = 146.57m, TaxAmountInPaymentCCY = 14.66m, GrantTotalInPaymentCCY = 161.23m, ExchangeRate = 1.187247m, Currency = "USD" }),
        new TestCaseData(new DateTime(2019, 7, 12), "EUR", 1000.00m).Returns(new TaxBO { PreTaxTotalInPaymentCCY = 1000.00m, TaxAmountInPaymentCCY = 90m, GrantTotalInPaymentCCY = 1090m, ExchangeRate = 1, Currency = "EUR" }),
        new TestCaseData(new DateTime(2020, 8, 19),  "CAD", 6543.21m).Returns(new TaxBO { PreTaxTotalInPaymentCCY =  10239.07m, TaxAmountInPaymentCCY = 1126.30m, GrantTotalInPaymentCCY = 11365.37m, ExchangeRate = 1.564839m, Currency = "CAD" })
        };

    [TestCaseSource(nameof(testCases))]
    public TaxBO CalculateTaxTest_Case1(DateTime invoiceDate, string currency, decimal amount)
    {
        var taxResult = _taxCalculatorService.CalculateTax(invoiceDate, currency, amount);
        Thread.Sleep(10000); 
        return taxResult.Result;
    }

}
