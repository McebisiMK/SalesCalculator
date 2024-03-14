using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using SalesCalculator.Common.Models.Configurations;
using SalesCalculator.Core.Services;
using SalesCalculator.Tests.TestData;

namespace SalesCalculator.Tests
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        private static IOptions<TaxOptions> _taxOptions;

        [SetUp]
        public void Setup()
        {
            var configuration = TaxTestData.CreateInMemoryConfigurations();
            _taxOptions = Options.Create(configuration.GetSection("TaxOptions").Get<TaxOptions>());
        }

        [Test]
        public void Calculate_Given_Price_Is_Zero_Return_Zero()
        {
            //----------------------- Arrange ----------------------
            var price = 0M;
            var expectedTaxAmount = 0M;

            var taxCalculatorService = CreateTaxCalculatorService();

            //----------------------- Act     ----------------------
            var actual = taxCalculatorService.Calculate(price, true, true);

            //----------------------- Assert  ----------------------
            actual.Should().Be(expectedTaxAmount);
        }

        [TestCase(12.49, true, false, 0)] // Product with exemption
        [TestCase(14.99, false, false, 1.50)] // Product with no exemption
        [TestCase(47.50, false, true, 7.15)] // Imported product with exemption
        [TestCase(10.00, true, true, 0.50)] // Imported product with no exemption
        public void Calculate_Given_Price_And_Tax_Details_Should_Return_Tax_Amount(decimal price, bool hasExemption, bool isImported, decimal expectedTaxAmount)
        {
            //----------------------- Arrange ----------------------
            var taxCalculatorService = CreateTaxCalculatorService();

            //----------------------- Act     ----------------------
            var actual = taxCalculatorService.Calculate(price, hasExemption, isImported);

            //----------------------- Assert  ----------------------
            actual.Should().Be(expectedTaxAmount);
        }



        private static TaxCalculatorService CreateTaxCalculatorService()
        {
            return new TaxCalculatorService(_taxOptions);
        }
    }
}
