namespace SalesTaxes.Test
{
    using FluentAssertions;
    using Models;
    using Xunit;

    public class ProductTests
    {
        public static TheoryData<Product, double, string> ProductsTheoryData =>
            new TheoryData<Product, double, string>
            {
                { new Book(false, "This is a book product 1", 1), 0d, "Should return a book product without tax because this is not an imported product." },
                { new Book(true, "This is a book product 2", 1), 0d, "Should return a book product without tax although it has a bad instance because is instanced like the imported product." },
                { new Cosmetic(true, "This is a cosmetic product 1", 1), 0.15d, "Should return a cosmetic product with taxes because this is an imported product." },
                { new Cosmetic(false, "This is a cosmetic product 2", 1), 0.1d, "Should return a cosmetic product with a normal tax because this product only has a normal tax." },
                { new Chocolate(true, "This is a chocolate product 1", 1), 0.05d, "Should return a chocolate product with taxes because this is an imported product." },
                { new Chocolate(false, "This is a chocolate product 2", 1), 0d, "Should return a chocolate product with a normal tax because this product has not tax." },
                { new Food(true, "This is a food product 1", 1), 0d, "Should return a food product without tax because this is not an imported product." },
                { new Food(false, "This is a food product 2", 1), 0d, "Should return a food product without tax although it has a bad instance because is instanced like the imported product." },
                { new Medical(true, "This is a medical product 1", 1), 0d, "Should return a medical product without tax because this is not an imported product." },
                {
                    new Medical(false, "This is a medical product 2", 1), 0d,
                    "Should return a medical without product tax although it has a bad instance because is instanced like the imported product."
                },
                { new Musical(true, "This is a musical product 1", 1), 0.15d, "Should return a musical product with taxes because this is an imported product." },
                { new Musical(false, "This is a musical product 2", 1), 0.1d, "Should return a musical product with a normal tax because this product only has a normal tax." }
            };

        [Theory]
        [MemberData(nameof(ProductsTheoryData))]
        public void CalculateTax_Ok(Product input, double expectedTax, string because)
        {
            double result = input.CalculateTax();

            result.Should().Be(expectedTax, because);
        }
    }
}