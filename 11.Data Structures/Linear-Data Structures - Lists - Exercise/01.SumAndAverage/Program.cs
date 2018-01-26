namespace _01.SumAndAverage
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

            double sum = 0.0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            double avarage = sum / numbers.Count();

            Console.WriteLine($"Sum={sum}; Average={avarage:f2}");
        }
    }
}