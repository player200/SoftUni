using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            int[] numberRange = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string type = Console.ReadLine();

            var numbers = Enumerable.Range(numberRange[0], numberRange[1] - numberRange[0] + 1);
            Predicate<int> isEven = n => n % 2 == 0;
            List<int> collector = new List<int>();
            foreach (var number in numbers)
            {
                if (isEven(number) &&type=="even")
                {
                    collector.Add(number);
                }
                else if (!isEven(number) && type == "odd")
                {
                    collector.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ",collector));
        }
    }
}