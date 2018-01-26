using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Filter_Students_by_Phone
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
            group.Where(x => x[2].StartsWith("02") || x[2].StartsWith("+3592"))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]}"));
        }
    }
}