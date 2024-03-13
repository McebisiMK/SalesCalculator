using SalesCalculator.Common.Models.Request;
using SalesCalculator.Common.Models.Response;

namespace SalesCalculator.Core.Interfaces
{
    public interface IReceiptGenerator
    {
        Receipt Generate(List<ShoppingBasketItem> items);
    }
}
