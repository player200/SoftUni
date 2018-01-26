using System;
using System.Text.RegularExpressions;
namespace _02.Vowel_Count
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"[AEIOUYaeiouy]");
            int counter = regex.Matches(text).Count;
            Console.WriteLine($"Vowels: {counter}");
        }
    }
}