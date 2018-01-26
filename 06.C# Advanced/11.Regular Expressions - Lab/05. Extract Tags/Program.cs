using System;
using System.Text.RegularExpressions;
namespace _05.Extract_Tags
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            while ((input=Console.ReadLine())!="END")
            {
                foreach (Match match in Regex.Matches(input, @"<.+?>"))
                {
                    Console.WriteLine("{0}", match);
                }
            }
        }
    }
}