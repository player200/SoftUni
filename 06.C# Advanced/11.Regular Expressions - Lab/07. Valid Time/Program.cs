using System;
using System.Text.RegularExpressions;
namespace _07.Valid_Time
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                Regex regex = new Regex(@"[01][0-9]:[0-5][\d]:[0-5][\d] (A|P)M"); 
                Match match = regex.Match(input);
                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}