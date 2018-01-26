using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace _07.Valid_Usernames
{
    class Program
    {
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(new[] { ' ', '(', ')','\\','/' },StringSplitOptions.RemoveEmptyEntries)
                .Where(u=>Regex.IsMatch(u, @"\b[a-zA-Z]\w{2,24}\b"))
                .ToArray();
            int bestLenght = 0;
            string bestFirstString = string.Empty;
            string bestSecondString = string.Empty;

            for (int i = 0; i < text.Length-1; i++)
            {
                string firstString = text[i];
                string secondString = text[i + 1];
                int currentLenth = firstString.Length + secondString.Length;
                if (bestLenght<currentLenth)
                {
                    bestLenght = currentLenth;
                    bestFirstString = firstString;
                    bestSecondString = secondString;
                }
            }
            Console.WriteLine(bestFirstString);
            Console.WriteLine(bestSecondString);
        }
    }
}