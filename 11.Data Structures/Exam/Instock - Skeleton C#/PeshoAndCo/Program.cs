
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        IProductStock stock = new Instock();
        const int count = 100_000;
        List<Product> people = new List<Product>();

        for (int i = 0; i < count; i++)
        {

            people.Add(new Product(i.ToString(), i, i));
            stock.Add(people[i]);
        }
        people.Sort();
        IEnumerable<Product> result = stock.FindFirstByAlphabeticalOrder(50000);

        // Assert
        var firstTest = people.Take(50000).ToList();
        var secondTest = result.ToList();
        Console.WriteLine();
    }
}

