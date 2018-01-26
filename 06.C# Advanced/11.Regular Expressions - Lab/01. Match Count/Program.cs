using System;
using System.Text.RegularExpressions;
namespace _01.Match_Count
{
    class Program
    {
        static void Main()
        {
            string regex = Console.ReadLine();
            string text = Console.ReadLine();
            int counter = 0;
            foreach (Match m in Regex.Matches(text, regex))
            {
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}