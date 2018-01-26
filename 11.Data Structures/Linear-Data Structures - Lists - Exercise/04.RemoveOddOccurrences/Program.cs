namespace _04.RemoveOddOccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            List<int> newList = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                foreach (var number in collector)
                {
                    if (numbers.Where(n => n == number).Count() % 2 == 0)
                    {
                        if (numbers[i] == numbers.Where(n => n == number).FirstOrDefault())
                        {
                            newList.Add(numbers[i]);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", newList).Trim());
        }
    }
}