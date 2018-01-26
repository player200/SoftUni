using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Filter_Students_by_Email_Domain
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
            group.Where(x=>x[2].EndsWith("@gmail.com"))
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]}"));
        }
    }
}