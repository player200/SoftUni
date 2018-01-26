using System;
using System.Text.RegularExpressions;
namespace _03.Series_Of_Letters
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(Regex.Replace(input, @"([A-Za-z])\1+","$1"));
        }
    }
}