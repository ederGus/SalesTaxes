namespace SalesTaxes.Models
{
    public class Medical : Product
    {
        /// <inheritdoc />
        public Medical(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax() => 0d;
    }
}