using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Students_by_Group
{
    class Program
    {
        static void Main()
        {
            List<string[]> group = new List<string[]>();
            string text = Console.ReadLine();
            while (text!="END")
            {
                group.Add(text.Split());
                text = Console.ReadLine();
            }
            group.Where(x => x[2] == "2")
                .OrderBy(x => x[0])
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]}"));
        }
    }
}