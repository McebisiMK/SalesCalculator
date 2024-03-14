using SalesCalculator.Common.Models.Request;
using SalesCalculator.Common.Models.Response;

namespace SalesCalculator.Tests.TestData
{
    public class ReceiptTestData
    {
        public static Receipt GetEmptyReceipt()
        {
            return new Receipt();
        }

        public static List<ShoppingBasketItem> GetFirstInputShoppingBasket()
        {
            return new List<ShoppingBasketItem>
            {
                new ShoppingBasketItem
                {
                    Name = "Book",
                    Quantity = 1,
                    Price = 12.49M,
                    HasExemption = true,
                    IsImported = false
                },
                new ShoppingBasketItem
                {
                    Name = "Music CD",
                    Quantity = 1,
                    Price = 14.99M,
                    HasExemption = false,
                    IsImported = false
                },
                new ShoppingBasketItem
                {
                    Name = "Chocolate bar",
                    Quantity = 1,
                    Price = 0.85M,
                    HasExemption = true,
                    IsImported = false
                }
            };
        }

        public static Receipt GetFirstOutputReceipt()
        {
            return new Receipt
            {
                Items = new List<ItemDTO>
                {
                    new ItemDTO
                    {
                        Name = "Book",
                        Quantity = 1,
                        Price = 12.49M
                    },
                    new ItemDTO
                    {
                        Name = "Music CD",
                        Quantity = 1,
                        Price = 16.49M
                    },
                    new ItemDTO
                    {
                        Name = "Chocolate bar",
                        Quantity = 1,
                        Price = 0.85M
                    }
                },
                SalesTax = 1.50M,
                Total = 29.83M
            };
        }

        public static List<ShoppingBasketItem> GetSecondInputShoppingBasket()
        {
            return new List<ShoppingBasketItem>
            {
                new ShoppingBasketItem
                {
                    Name = "Imported box of chocolates",
                    Quantity = 1,
                    Price = 10.00M,
                    HasExemption = true,
                    IsImported = true
                },
                new ShoppingBasketItem
                {
                    Name = "Imported bottle of perfume",
                    Quantity = 1,
                    Price = 47.50M,
                    HasExemption = false,
                    IsImported = true
                }
            };
        }

        public static Receipt GetSecondOutputReceipt()
        {
            return new Receipt
            {
                Items = new List<ItemDTO>
                {
                    new ItemDTO
                    {
                        Name = "Imported box of chocolates",
                        Quantity = 1,
                        Price = 10.50M
                    },
                    new ItemDTO
                    {
                        Name = "Imported bottle of perfume",
                        Quantity = 1,
                        Price = 54.65M
                    }
                },
                SalesTax = 7.65M,
                Total = 65.15M
            };
        }

        public static List<ShoppingBasketItem> GetThirdInputShoppingBasket()
        {
            return new List<ShoppingBasketItem>
            {
                new ShoppingBasketItem
                {
                    Name = "Imported bottle of perfume",
                    Quantity = 1,
                    Price = 27.99M,
                    HasExemption = false,
                    IsImported = true
                },
                new ShoppingBasketItem
                {
                    Name = "Bottle of perfume",
                    Quantity = 1,
                    Price = 18.99M,
                    HasExemption = false,
                    IsImported = false
                },
                new ShoppingBasketItem
                {
                    Name = "Packet of paracetamol",
                    Quantity = 1,
                    Price = 9.75M,
                    HasExemption = true,
                    IsImported = false
                },
                new ShoppingBasketItem
                {
                    Name = "Box of imported chocolates",
                    Quantity = 1,
                    Price = 11.25M,
                    HasExemption = true,
                    IsImported = true
                }
            };
        }

        public static Receipt GetThirdOutputReceipt()
        {
            return new Receipt
            {
                Items = new List<ItemDTO>
                {
                    new ItemDTO
                {
                    Name = "Imported bottle of perfume",
                    Quantity = 1,
                    Price = 32.19M
                },
                new ItemDTO
                {
                    Name = "Bottle of perfume",
                    Quantity = 1,
                    Price = 20.89M
                },
                new ItemDTO
                {
                    Name = "Packet of paracetamol",
                    Quantity = 1,
                    Price = 9.75M
                },
                new ItemDTO
                {
                    Name = "Box of imported chocolates",
                    Quantity = 1,
                    Price = 11.85M
                }
                },
                SalesTax = 6.70M,
                Total = 74.68M
            };
        }
    }
}
