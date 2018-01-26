using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Reverse_And_Exclude
{
    class Program
    {
        static void Main()
        {
            int[] numbersCollection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> isNotDevided = n => n % divider!=0;
            List<int> result = new List<int>();
            foreach (var number in numbersCollection)
            {
                if (isNotDevided(number))
                {
                    result.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ",result.ToArray().Reverse()));
        }
    }
}