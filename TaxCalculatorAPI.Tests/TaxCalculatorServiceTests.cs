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

    [Test, Order(1)]
    public void CalculateTaxTest_Case1()
    {
        DateTime invoiceDate = new DateTime(2020, 8, 5);
        var taxResult = _taxCalculatorService.CalculateTax(invoiceDate, "USD", 123.45m);

        Assert.That(taxResult.Result.PreTaxTotalInPaymentCCY, Is.EqualTo(146.57m));
        Assert.That(taxResult.Result.TaxAmountInPaymentCCY, Is.EqualTo(14.66m));
        Assert.That(taxResult.Result.GrantTotalInPaymentCCY, Is.EqualTo(161.23m));
        Assert.That(taxResult.Result.ExchangeRate, Is.EqualTo(1.187247));
        Assert.Pass();
    }

    [Test, Order(2)]
    public void CalculateTaxTest_Case2()
    {
        DateTime invoiceDate = new DateTime(2019, 7, 12);
        var taxResult = _taxCalculatorService.CalculateTax(invoiceDate, "EUR", 1000.00m);

        Assert.That(taxResult.Result.PreTaxTotalInPaymentCCY, Is.EqualTo(1000.00m));
        Assert.That(taxResult.Result.TaxAmountInPaymentCCY, Is.EqualTo(90m));
        Assert.That(taxResult.Result.GrantTotalInPaymentCCY, Is.EqualTo(1090m));
        Assert.That(taxResult.Result.ExchangeRate, Is.EqualTo(1));
        Assert.Pass();
    }

    [Test, Order(3)]
    public void CalculateTaxTest_Case3()
    {
        DateTime invoiceDate = new DateTime(2020, 8, 19);
        var taxResult = _taxCalculatorService.CalculateTax(invoiceDate, "CAD", 6543.21m);

        Assert.That(taxResult.Result.PreTaxTotalInPaymentCCY, Is.EqualTo(10239.07m));
        Assert.That(taxResult.Result.TaxAmountInPaymentCCY, Is.EqualTo(1126.30m));
        Assert.That(taxResult.Result.GrantTotalInPaymentCCY, Is.EqualTo(11365.37m));
        Assert.That(taxResult.Result.ExchangeRate, Is.EqualTo(1.564839));
        Assert.Pass();
    }

    [TearDown]
    public void AfterEachTest()
    {
        Thread.Sleep(10000); // Delay for 10 second
    }
}
