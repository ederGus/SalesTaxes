namespace SalesTaxes
{
    using System;

    public abstract class Product
    {
        protected Product(bool isImported, string name, double price)
        {
            this.IsImported = isImported;
            this.Name = name;
            this.Price = price;
        }

        public bool IsImported { get; }

        public string Name { get; }

        public double Price { get; }

        public double PriceWithTax => Math.Truncate((this.Price + this.CalculateTax()) * 100) / 100;

        public abstract double CalculateTax();

        protected double GetTotalTax(double totalTax) =>  this.Price * totalTax;
    }
}