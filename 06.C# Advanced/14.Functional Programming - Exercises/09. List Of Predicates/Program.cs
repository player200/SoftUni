using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main()
        {
            int maxNum = int.Parse(Console.ReadLine());
            if (maxNum<1)
            {
                return;
            }

            List<int> numbers = new List<int>(Enumerable.Range(1, maxNum));

            List<int> divisors = Console.ReadLine()
                .Split().Select(int.Parse)
                .Distinct()
                .ToList();

            Predicate<int> isDivisible = x =>
            {
                bool divisible = true;
                foreach (var num in divisors)
                {
                    if (x % num != 0)
                    {
                        divisible = false;
                        break;
                    }
                }

                return divisible;
            };

            numbers = numbers.Where(x => isDivisible(x)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}