using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Students_by_Age
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
            group.Where(x =>int.Parse(x[2])>=18 && int.Parse(x[2])<=24)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]} {x[2]}"));
        }
    }
}