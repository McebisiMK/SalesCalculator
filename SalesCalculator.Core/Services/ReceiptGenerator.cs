using SalesCalculator.Common.Models.Request;
using SalesCalculator.Common.Models.Response;
using SalesCalculator.Core.Interfaces;

namespace SalesCalculator.Core.Services
{
    public class ReceiptGenerator : IReceiptGenerator
    {
        private readonly ITaxCalculatorService _taxCalculatorService;

        public ReceiptGenerator(ITaxCalculatorService taxCalculatorService)
        {
            _taxCalculatorService = taxCalculatorService;
        }

        public Receipt Generate(List<ShoppingBasketItem> items)
        {
            var invoice = new Receipt();

            items.ForEach(item =>
            {
                var productTaxAmount = _taxCalculatorService.Calculate(item.Price, item.HasExemption, item.IsImported);
                var price = item.Price + productTaxAmount;

                invoice.Items.Add(new ItemDTO
                {
                    Name = item.Name,
                    Price = price,
                    Quantity = item.Quantity
                });

                invoice.SalesTax += productTaxAmount;
                invoice.Total += price;
            });

            return invoice;
        }
    }
}
