namespace SalesTaxes.Test
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class CartItemTests
    {
        public static TheoryData<CartItem, double, double, string> CartItemsTheoryData =>
            new TheoryData<CartItem, double, double, string>
            {
                {
                    new CartItem(new List<Item> { new Item(2, new Book(false, "Book 1", 2d)) }),
                    0d,
                    4d,
                    "Should return a cart item with SalesTaxes = 0 and Total = 4 because the book has no taxes."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Cosmetic(false, "Cosmetic 1", 2d)) }),
                    0.4d,
                    4.4d,
                    "Should return a cart item with SalesTaxes = 0.4 and Total = 4.4 because the cosmetic has only normal tax."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Cosmetic(true, "Cosmetic 2", 2d)) }),
                    0.60000000000000009d,
                    4.6000000000000005d,
                    "Should return a cart item with SalesTaxes = 0.4 and Total = 4.4 because the cosmetic has only normal tax."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Chocolate(false, "Chocolate 1", 2d)) }),
                    0d,
                    4d,
                    "Should return a cart item with SalesTaxes = 0 and Total = 4 because the chocolate is not imported."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Chocolate(true, "Chocolate 2", 2d)) }),
                    0.2d,
                    4.2d,
                    "Should return a cart item with SalesTaxes = 0.2 and Total = 4.2 because the chocolate is imported."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Food(false, "Book 1", 2d)) }),
                    0d,
                    4d,
                    "Should return a cart item with SalesTaxes = 0 and Total = 4 because the food has no taxes."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Medical(false, "Book 1", 2d)) }),
                    0d,
                    4d,
                    "Should return a cart item with SalesTaxes = 0 and Total = 4 because the medical has no taxes."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Musical(false, "CD 1", 2d)) }),
                    0.4d,
                    4.4d,
                    "Should return a cart item with SalesTaxes = 0.4 and Total = 4.4 because the CD has only normal tax."
                },
                {
                    new CartItem(new List<Item> { new Item(2, new Musical(true, "Musical 2", 2d)) }),
                    0.60000000000000009d,
                    4.6000000000000005d,
                    "Should return a cart item with SalesTaxes = 0.6 and Total = 4.6 because the musical has only normal tax."
                }
            };

        [Theory]
        [MemberData(nameof(CartItemsTheoryData))]
        public void SalesTotalAndTotal_Ok(CartItem inputCartItem, double expectedSalesTaxes, double expectedTotal, string because)
        {
            double salesTaxes = inputCartItem.SalesTaxes;
            double total = inputCartItem.Total;

            salesTaxes.Should().Be(expectedSalesTaxes, because);
            total.Should().Be(expectedTotal, because);
        }
    }
}