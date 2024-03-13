namespace SalesCalculator.Common.Models.Response
{
    public class Receipt
    {
        public List<ItemDTO> Items { get; set; } = new List<ItemDTO>();
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}
