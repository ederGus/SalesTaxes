namespace SalesTaxes.Models
{
    using System;

    public class Chocolate : Product
    {
        /// <inheritdoc />
        public Chocolate(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax()
        {
            const double ImportedProductsTax = 0.05d;
            double taxes = this.IsImported ? ImportedProductsTax : 0d;

            return this.GetTotalTax(taxes);
        }
    }
}