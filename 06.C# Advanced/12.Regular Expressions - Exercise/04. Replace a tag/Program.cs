using System;
using System.Text.RegularExpressions;
namespace _04.Replace_a_tag
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            while ((input=Console.ReadLine())!="end")
            {
                string pattern = @"<a (href=.+?)>(.+)</a>";
                Console.WriteLine(Regex.Replace(input,pattern,w=> $"[URL {w.Groups[1].Value}]{w.Groups[2].Value}[/URL]"));
            }
        }
    }
}