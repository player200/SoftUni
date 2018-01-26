using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.Students_Enrolled_in_2014_or_2015
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
            group.Where(x => x[0].EndsWith("14")|| x[0].EndsWith("15"))
                .ToList()
                .ForEach(x => Console.WriteLine($"{string.Join(" ",x.Skip(1))}"));
        }
    }
}