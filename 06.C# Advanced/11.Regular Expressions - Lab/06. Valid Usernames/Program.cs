using System;
using System.Text.RegularExpressions;
namespace _06.Valid_Usernames
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            while ((input=Console.ReadLine())!="END")
            {
                Regex regex = new Regex(@"^[\w-]{3,16}$",RegexOptions.Multiline);
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