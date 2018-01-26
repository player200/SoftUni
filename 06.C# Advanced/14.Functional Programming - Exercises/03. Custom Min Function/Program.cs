using System;
using System.Linq;
namespace _03.Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();
            Func<int[], int> smallerNumber = num => num.Min();
            Console.WriteLine(smallerNumber(numbers));
        }
    }
}