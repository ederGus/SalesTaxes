namespace SalesTaxes.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Models;
    using Xunit;

    public class InvoiceTests
    {
        private const string Imported = "imported";
        private const string SalesTaxes = "Sales Taxes: ";
        private const string Total = "Total: ";

        [Fact]
        public void GenerateInvoiceNoProductsImported_Ok()
        {
            List<string> expectedResult = new List<string>
            {
                "2  Book for testing : 15",
                $"{SalesTaxes}0",
                $"{Total}30"
            };
            CartItem cartItem = new CartItem(new List<Item> { new Item(2, new Book(false, "Book for testing", 15d)) });
            Invoice invoice = new Invoice(cartItem);

            List<string> result = invoice.GenerateInvoice().ToList();

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GenerateInvoiceWithProductsImported_Ok()
        {
            List<string> expectedResult = new List<string>
            {
                $"2 {Imported} CD for testing : 17.25",
                $"{SalesTaxes}4.5",
                $"{Total}34.5"
            };
            CartItem cartItem = new CartItem(new List<Item> { new Item(2, new Musical(true, "CD for testing", 15d)) });
            Invoice invoice = new Invoice(cartItem);

            List<string> result = invoice.GenerateInvoice().ToList();

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}