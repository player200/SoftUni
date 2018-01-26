using System;
using System.Linq;
namespace _02.Upper_Strings
{
    class Program
    {
        static void Main()
        {
            var inputText = Console.ReadLine()
                .Split(' ')
                .Select(t => t.ToUpper())
                .ToList();
            Console.WriteLine(string.Join(" ",inputText));
        }
    }
}