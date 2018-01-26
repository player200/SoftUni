using System;
using System.Collections.Generic;
namespace _04.Special_Words
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string text = Console.ReadLine();
            Dictionary<string,int> specialDictionary = new Dictionary<string, int>();

            string[] specialWords = input.Split(' ');
            string[] textItems = text
                .Split(new[] {' ','-','(',')','[',']','<', '>', ',', '!','?' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < specialWords.Length; i++)
            {
                specialDictionary.Add(specialWords[i], 0);
            }

            for (int i = 0; i < textItems.Length; i++)
            {
                if (specialDictionary.ContainsKey(textItems[i]))
                {
                    specialDictionary[textItems[i]]++;
                }
            }

            foreach (var wordCount in specialDictionary)
            {
                Console.WriteLine($"{wordCount.Key} - {wordCount.Value}");
            }
        }
    }
}