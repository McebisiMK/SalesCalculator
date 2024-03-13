namespace SalesCalculator.Common.Models.Request
{
    public class ShoppingBasketItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsImported { get; set; }
        public bool HasExemption { get; set; }
    }
}
