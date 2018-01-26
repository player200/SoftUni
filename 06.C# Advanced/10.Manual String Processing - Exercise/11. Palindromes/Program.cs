using System;
using System.Collections.Generic;
namespace _11.Palindromes
{
    class Program
    {
        static void Main()
        {
            var collector = new SortedSet<string>();
            string[] textInput = Console.ReadLine()
                .Split(new[] {' ',',','.','?','!' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textInput.Length; i++)
            {
                char[] array = textInput[i].ToCharArray();
                Array.Reverse(array);
                string reverseWord = new string(array);
                if (textInput[i] == reverseWord)
                {
                    collector.Add(textInput[i]);
                }
            }
            Console.WriteLine($"[{string.Join(", ",collector)}]");
        }
    }
}