using System;
using System.Linq;
namespace _04.Add_VAT
{
    class Program
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine();

            inputNumbers
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }
    }
}