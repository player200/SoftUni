using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Students_by_First_and_Last_Name
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
            group.Where(s => s[0].CompareTo(s[1]) == -1)
                .ToList()
                .ForEach(r => Console.WriteLine($"{r[0]} {r[1]}"));
        }
    }
}