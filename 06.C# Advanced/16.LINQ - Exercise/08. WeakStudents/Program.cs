using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.WeakStudents
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
            group.Where(x => x.Skip(2).Count(n=>int.Parse(n)<=3)>=2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x[0]} {x[1]}"));
        }
    }
}