using Inheritance.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Product #{i} data: ");
                Console.Write("Common, user or imported (c/u/i)? ");
                char resp = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (resp == 'c')
                {
                    products.Add(new Product(name, price));
                }
                else if (resp == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    products.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, fee));
                }
            }

            Console.WriteLine();

            Console.WriteLine("PRICE TAGS:");

            foreach(Product p in products)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
