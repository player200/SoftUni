using System;
using System.Text.RegularExpressions;
namespace _01.Match_Full_Name
{
    class Program
    {
        static void Main()
        {
            string inputName = Console.ReadLine();
            while (inputName!="end")
            {
                Match collection = Regex.Match(inputName, @"(\b[A-Z][a-zA-Z]+\b)\s(\b[A-Z][a-zA-Z]+\b)");
                if (collection.Success)
                {
                    Console.WriteLine(collection.Value);
                }
                inputName = Console.ReadLine();
            }
        }
    }
}