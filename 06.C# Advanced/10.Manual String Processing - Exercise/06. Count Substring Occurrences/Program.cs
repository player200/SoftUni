using System;
namespace _06.Count_Substring_Occurrences
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string index = Console.ReadLine().ToLower();

            int foundIndex = -1;
            int counter = 0;
            while ((foundIndex = text.IndexOf(index, foundIndex + 1)) != -1)
            {
                ++counter;
            }
            Console.WriteLine(counter);
        }
    }
}