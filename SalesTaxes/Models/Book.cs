namespace SalesTaxes.Models
{
    public class Book : Product
    {
        /// <inheritdoc />
        public Book(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax() => 0d;
    }
}