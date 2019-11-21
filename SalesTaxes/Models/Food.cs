namespace SalesTaxes.Models
{
    public class Food : Product
    {
        /// <inheritdoc />
        public Food(bool isImported, string name, double price)
            : base(isImported, name, price)
        {
        }

        /// <inheritdoc />
        public override double CalculateTax() => 0d;
    }
}