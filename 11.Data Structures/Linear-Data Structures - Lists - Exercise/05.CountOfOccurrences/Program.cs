namespace _05.CountOfOccurrences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            SortedSet<int> collector = new SortedSet<int>();

            foreach (var number in numbers)
            {
                collector.Add(number);
            }

            foreach (var number in collector)
            {
                Console.WriteLine(value: $"{number} -> {numbers.Where(n=>n==number).Count()} times");
            }
        }
    }
}