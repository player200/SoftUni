using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Sort_Students
{
    class Program
    {
        static void Main()
        {
            List<string[]> group = new List<string[]>();
            string text = Console.ReadLine();
            while (text != "END")
            {
                group.Add(text.Split());
                text = Console.ReadLine();
            }
            group.OrderBy(x=>x[1])
                .ThenByDescending(x=>x[0])
                .ToList()
                .ForEach(r => Console.WriteLine($"{r[0]} {r[1]}"));
        }
    }
}