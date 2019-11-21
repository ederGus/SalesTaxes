namespace SalesTaxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class CartItem
    {
        public CartItem(IEnumerable<Item> items)
        {
            this.Items = items ?? Enumerable.Empty<Item>();
        }

        public IEnumerable<Item> Items { get; set; }

        public double SalesTaxes => Math.Ceiling((this.Items.Sum(item => item.Product.CalculateTax() * item.Quantity)) / 0.05d) * 0.05d;

        public double Total => Math.Ceiling((this.SalesTaxes + this.Items.Sum(item => item.Price * item.Quantity)) / 0.05d) * 0.05d;
    }
}