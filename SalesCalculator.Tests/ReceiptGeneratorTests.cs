using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SalesCalculator.Common.Models.Request;
using SalesCalculator.Core.Interfaces;
using SalesCalculator.Core.Services;
using SalesCalculator.Tests.TestData;

namespace SalesCalculator.Tests
{
    [TestFixture]
    public class ReceiptGeneratorTests
    {
        private ITaxCalculatorService _taxCalculatorService;

        [SetUp]
        public void Setup()
        {
            var serviceProvider = TaxTestData.CreateServiceProvider();
            _taxCalculatorService = serviceProvider.GetRequiredService<ITaxCalculatorService>();
        }

        [Test]
        public void Generate_Given_Empty_List_Of_Shopping_Basket_Items_Should_Return_Empty_Receipt()
        {
            //---------------------------------- Arrange ----------------------------------
            var shoppingBasket = new List<ShoppingBasketItem>();
            var expectedReceipt = ReceiptTestData.GetEmptyReceipt();

            var receiptGenerator = CreateReceiptGenerator();

            //---------------------------------- Act     ----------------------------------
            var actual = receiptGenerator.Generate(shoppingBasket);

            //---------------------------------- Assert  ----------------------------------
            actual.Items.Should().BeEmpty();
            actual.Should().BeEquivalentTo(expectedReceipt);
        }

        [Test]
        public void Generate_Given_First_List_Of_Shopping_Basket_Items_Should_Return_First_Receipt()
        {
            //---------------------------------- Arrange ----------------------------------
            var shoppingBasket = ReceiptTestData.GetFirstInputShoppingBasket();
            var expectedReceipt = ReceiptTestData.GetFirstOutputReceipt();

            var receiptGenerator = CreateReceiptGenerator();

            //---------------------------------- Act     ----------------------------------
            var actual = receiptGenerator.Generate(shoppingBasket);

            //---------------------------------- Assert  ----------------------------------
            actual.Items.Should().HaveCount(shoppingBasket.Count);
            actual.Should().BeEquivalentTo(expectedReceipt);
        }

        [Test]
        public void Generate_Given_Second_List_Of_Shopping_Basket_Items_Should_Return_Second_Receipt()
        {
            //---------------------------------- Arrange ----------------------------------
            var shoppingBasket = ReceiptTestData.GetSecondInputShoppingBasket();
            var expectedReceipt = ReceiptTestData.GetSecondOutputReceipt();

            var receiptGenerator = CreateReceiptGenerator();

            //---------------------------------- Act     ----------------------------------
            var actual = receiptGenerator.Generate(shoppingBasket);

            //---------------------------------- Assert  ----------------------------------
            actual.Items.Should().HaveCount(shoppingBasket.Count);
            actual.Should().BeEquivalentTo(expectedReceipt);
        }

        [Test]
        public void Generate_Given_Third_List_Of_Shopping_Basket_Items_Should_Return_Third_Receipt()
        {
            //---------------------------------- Arrange ----------------------------------
            var shoppingBasket = ReceiptTestData.GetThirdInputShoppingBasket();
            var expectedReceipt = ReceiptTestData.GetThirdOutputReceipt();

            var receiptGenerator = CreateReceiptGenerator();

            //---------------------------------- Act     ----------------------------------
            var actual = receiptGenerator.Generate(shoppingBasket);

            //---------------------------------- Assert  ----------------------------------
            actual.Items.Should().HaveCount(shoppingBasket.Count);
            actual.Should().BeEquivalentTo(expectedReceipt);
        }

        private ReceiptGenerator CreateReceiptGenerator()
        {
            return new ReceiptGenerator(_taxCalculatorService);
        }
    }
}
