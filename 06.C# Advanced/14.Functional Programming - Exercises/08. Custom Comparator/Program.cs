using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.Custom_Comparator
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>,List<int> > even = n =>n.Where(x=>x%2==0).OrderBy(x => x).ToList();
            Func<List<int>, List<int>> odd = n =>n.Where(x => x % 2 != 0).OrderBy(x=>x).ToList();
            List<int> result = new List<int>();
            foreach (var number in even(numbers))
            {
                result.Add(number);
            }
            foreach (var number in odd(numbers))
            {
                result.Add(number);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}