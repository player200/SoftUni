using System;
using System.Linq;
namespace _05.Min_Even_Number
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToArray();
            if (numbers.Length==0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{numbers.Min():f2}");
            }
        }
    }
}