namespace SalesTaxes.Models
{
    using System;

    public class Musical : Product
    {
        /// <inheritdoc />
        public Musical(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax()
        {
            const double Tax = 0.1;
            const double ImportedProductsTax = 0.05;
            double taxes = this.IsImported ? Math.Truncate((Tax + ImportedProductsTax) * 100) / 100 : Tax;

            return this.GetTotalTax(taxes);
        }
    }
}