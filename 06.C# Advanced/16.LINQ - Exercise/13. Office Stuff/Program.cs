using System;
using System.Collections.Generic;
using System.Linq;
namespace _13.Office_Stuff
{
    class Program
    {
        static void Main()
        {
            var ordersCount = int.Parse(Console.ReadLine());
            var orders = new List<Order>();
            for (int i = 0; i < ordersCount; i++)
            {
                var order = Console.ReadLine()
                    .Trim('|')
                    .Split('-')
                    .Select(x => x.Trim())
                    .ToArray();
                orders.Add(new Order(order[0], order[2], int.Parse(order[1])));
            }
            orders
                .GroupBy(or => or.CompanyName)
                .OrderBy(x => x.Key)
                .Select(gr => gr.GroupBy(pr => pr.ProductName)
                      .Select(prg => new
                      {
                          CompanyName = gr.Key,
                          ProdName = prg.Key,
                          Amount = prg.Sum(x => x.Amount)
                      })
                       )
                .ToList()
                .ForEach(list => Console.WriteLine(list.Select(x => x.CompanyName)
                .First() + ": " + string.Join(", ", list.Select(x => $"{x.ProdName}-{x.Amount}"))));
        }

        private class Order
        {
            public string CompanyName;
            public string ProductName;
            public int Amount;

            public Order(string companyName, string productName, int amount)
            {
                CompanyName = companyName;
                ProductName = productName;
                Amount = amount;
            }
        }
    }
}