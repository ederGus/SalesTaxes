namespace SalesTaxes
{
    using System;
    using System.Collections.Generic;
    using Models;

    internal class Program
    {
        private static void Main()
        {
            const string BreakLine = "---------------------------------------------------";

            Console.WriteLine("OUTPUT");

            List<Item> items = new List<Item>
            {
                new Item(1, new Book(false, "Book", 12.49d)),
                new Item(1, new Musical(false, "Music CD", 14.99d)),
                new Item(1, new Chocolate(false, "Chocolate bar", 0.85d))
            };
            Console.WriteLine("Output 1:");
            PrintInvoice(new CartItem(items));
            Console.WriteLine(BreakLine);

            List<Item> items2 = new List<Item>
            {
                new Item(1, new Chocolate(true, "Box of chocolate", 10.00d)),
                new Item(1, new Cosmetic(true, "Bottle of perfume ", 47.50d))
            };
            Console.WriteLine("Output 2:");
            PrintInvoice(new CartItem(items2));
            Console.WriteLine(BreakLine);

            List<Item> items3 = new List<Item>
            {
                new Item(1, new Cosmetic(true, "Bottle of perfume ", 27.99d)),
                new Item(1, new Cosmetic(false, "Bottle of perfume ", 18.99d)),
                new Item(1, new Medical(false, "Packet of headache pills  ", 9.75d)),
                new Item(1, new Chocolate(true, "Box of chocolate", 11.25d)),
            };
            Console.WriteLine("Output 3:");
            PrintInvoice(new CartItem(items3));
            Console.WriteLine(BreakLine);
        }

        private static void PrintInvoice(CartItem cartItem)
        {
            Invoice invoice = new Invoice(cartItem);
            IEnumerable<string> invoiceLines = invoice.GenerateInvoice();
            foreach (string line in invoiceLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}