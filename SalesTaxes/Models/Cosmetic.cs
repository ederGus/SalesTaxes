namespace SalesTaxes.Models
{
    using System;

    public class Cosmetic : Product
    {
        /// <inheritdoc />
        public Cosmetic(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax()
        {
            const double Tax = 0.1d;
            const double ImportedProductsTax = 0.05d;
            double taxes = this.IsImported ? Math.Truncate((Tax + ImportedProductsTax) * 100) / 100 : Tax;

            return this.GetTotalTax(taxes);
        }
    }
}