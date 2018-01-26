using System;
using System.Text.RegularExpressions;
namespace _06.Sentence_Extractor
{
    class Program
    {
        static void Main()
        {
            string input=Console.ReadLine();
            string text = Console.ReadLine();
            string pattern=($@"([a-zA-Z0-9 ]+\b{input}\b\s*.*?[?!.])");
            foreach (Match match in Regex.Matches(text, pattern))
            {
                Console.WriteLine("{0}", match.Groups[1].Value);
            }
        }
    }
}