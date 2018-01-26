using System;
using System.Text.RegularExpressions;
namespace _02.Match_Phone_Number
{
    class Program
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();
            while (inputNumber!="end")
            {
                Match match = Regex.Match(inputNumber, @"^\+359( |-)2\1[0-9]{3}\1[0-9]{4}$");
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
                inputNumber = Console.ReadLine();
            }
        }
    }
}