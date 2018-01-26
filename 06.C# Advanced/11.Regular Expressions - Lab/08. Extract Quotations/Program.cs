using System;
using System.Text.RegularExpressions;
namespace _08.Extract_Quotations
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            foreach (Match match in Regex.Matches(input, "('|\")(.+?)\\1", RegexOptions.Multiline))
            {
                Console.WriteLine($"{match.Groups[2].Value}");
            }
        }
    }
}