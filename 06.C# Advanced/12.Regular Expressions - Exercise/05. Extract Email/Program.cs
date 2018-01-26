using System;
using System.Text.RegularExpressions;
namespace _05.Extract_Email
{
    class Program
    {
        static void Main()
        {
            string inputText = Console.ReadLine();
            MatchCollection matches = Regex
                .Matches(inputText, @"(?<=\s|^)[a-z0-9]+(?:[-._][a-z0-9]+)*@[a-z0-9]+(?:[-][a-z0-9]*)*\.[a-z]+(?:\.[a-z]+)*");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}