namespace SalesTaxes
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Invoice
    {
        public Invoice(CartItem cartItem)
        {
            this.CartItem = cartItem;
        }

        public CartItem CartItem { get; set; }

        public IEnumerable<string> GenerateInvoice()
        {
            List<string> invoice = new List<string>();
            if (!this.CartItem.Items.Any())
            {
                return invoice;
            }

            const string Imported = "imported";
            const string SalesTaxes = "Sales Taxes: ";
            const string Total = "Total: ";
            foreach (Item item in this.CartItem.Items)
            {
                string imported = item.Product.IsImported ? Imported : string.Empty;
                invoice.Add($"{item.Quantity} {imported} {item.Product.Name} : {item.Product.PriceWithTax}");
            }
            invoice.Add($"{SalesTaxes}{this.CartItem.SalesTaxes}");
            invoice.Add($"{Total}{this.CartItem.Total}");

            return invoice;
        }
    }
}