using System;
using System.Linq;
namespace _02.Sum_Numbers
{
    class Program
    {
        static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new string[] {", " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(inputNumbers.Count());
            Console.WriteLine(inputNumbers.Sum());
        }
    }
}