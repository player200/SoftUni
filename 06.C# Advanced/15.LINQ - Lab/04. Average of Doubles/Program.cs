using System;
using System.Linq;
namespace _04.Average_of_Doubles
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            Console.WriteLine($"{numbers.Sum()/numbers.Count():f2}");
        }
    }
}