namespace SalesTaxes.Models
{
    public class Item
    {
        public Item(int quantity, Product product)
        {
            this.Quantity = quantity;
            this.Product = product;
        }

        public double Price => this.Product.Price;

        public Product Product { get; }

        public int Quantity { get; }
    }
}