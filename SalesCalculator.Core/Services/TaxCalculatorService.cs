using Microsoft.Extensions.Options;
using SalesCalculator.Common.Models.Configurations;
using SalesCalculator.Core.Interfaces;

namespace SalesCalculator.Core.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly TaxOptions _taxOptions;

        public TaxCalculatorService(IOptions<TaxOptions> taxOptions)
        {
            _taxOptions = taxOptions.Value;
        }

        public decimal Calculate(decimal price, bool hasExemption, bool isImported)
        {
            if (price == 0) return 0;

            var productTaxAmount = 0M;

            productTaxAmount += GetTaxAmount(price, hasExemption);
            productTaxAmount += GetImportTaxAmount(price, isImported);

            return productTaxAmount;
        }

        private decimal GetImportTaxAmount(decimal price, bool isImported)
        {
            if (!isImported) return 0;

            return Math.Ceiling((price * (_taxOptions.ImportRate / 100)) * 20) / 20;
        }

        private decimal GetTaxAmount(decimal price, bool hasExemption)
        {
            if (hasExemption) return 0;

            return Math.Ceiling((price * (_taxOptions.TaxRate / 100)) * 20) / 20;
        }
    }
}
