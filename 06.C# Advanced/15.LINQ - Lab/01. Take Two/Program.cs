using System;
using System.Linq;
namespace _01.Take_Two
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => n >= 10 && n <= 20)
                .Distinct()
                .Take(2)
                .ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}