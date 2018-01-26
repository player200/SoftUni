using System;
using System.Text.RegularExpressions;
namespace _03.Non_Digit_Count
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"[^0123456789]");
            int counter = regex.Matches(text).Count;
            Console.WriteLine($"Non-digits: {counter}");
        }
    }
}