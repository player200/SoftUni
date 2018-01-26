using System;
using System.Linq;
namespace _03.First_Name
{
    class Program
    {
        static void Main()
        {
            var inputText = Console.ReadLine()
                .Split(new[] {" " },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var inputSymbols = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => char.ToLower(char.Parse(i)))
                .ToArray();
            var result = inputText
                .Where(name => Array.IndexOf(inputSymbols, Char.ToLower(name[0])) >= 0)
                .OrderBy(r => r)
                .FirstOrDefault();
            if (result==null)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(result);
            }
        }
    }
}