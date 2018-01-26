using System;
using System.Text.RegularExpressions;
namespace _04.Extract_Integer_Numbers
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            foreach (Match m in Regex.Matches(text, @"[0-9]{1,}"))
            {
                Console.WriteLine("{0}", m.Value);
            }
        }
    }
}