using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        ShoppingCenter shoppingCenter = new ShoppingCenter();
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string commandLine = Console.ReadLine();

            string command = commandLine.Remove(commandLine.IndexOf(' '));
            string[] items = commandLine
                .Substring(command.Length + 1)
                .Split(';');

            switch (command)
            {
                case "AddProduct":
                    Product product = new Product(items[0], double.Parse(items[1], CultureInfo.InvariantCulture), items[2]);
                    shoppingCenter.AddProduct(product);
                    Console.WriteLine("Product added");
                    break;
                case "DeleteProducts":
                    int count = 0;

                    if (items.Length == 2)
                    {
                        count = shoppingCenter.DeleteProducts(items[0], items[1]);
                    }
                    else if (items.Length == 1)
                    {
                        count = shoppingCenter.DeleteProducts(items[0]);
                    }

                    string resultToPrint = count > 0 ?
                        $"{count} products deleted" : "No products found";
                    Console.WriteLine(resultToPrint);

                    break;
                case "FindProductsByName":
                    IEnumerable<Product> findProducts = shoppingCenter
                        .FindProductsByName(items[0])
                        .ToList();

                    if (findProducts.Count() == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", findProducts));
                    }

                    break;
                case "FindProductsByProducer":
                    IEnumerable<Product> findProductsByProducer = shoppingCenter
                        .FindProductsByProducer(items[0])
                        .ToList();

                    if (findProductsByProducer.Count() == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", findProductsByProducer));
                    }

                    break;
                case "FindProductsByPriceRange":
                    IEnumerable<Product> findInRange =
                        shoppingCenter.FindProductsByPriceRange(
                                double.Parse(items[0], CultureInfo.InvariantCulture),
                                double.Parse(items[1], CultureInfo.InvariantCulture))
                                .ToList();

                    if (findInRange.Count() == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", findInRange));
                    }

                    break;
            }
        }
    }
}