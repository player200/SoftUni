using System;
namespace _09.Text_Filter
{
    class Program
    {
        static void Main()
        {
            string[] banWords = Console.ReadLine()
                .Split(new[] {',',' ' },StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();
            string replacement = string.Empty;
            for (int i = 0; i < banWords.Length; i++)
            {
                replacement = new string('*', banWords[i].Length);
                text = text.Replace(banWords[i], replacement);
            }
            Console.WriteLine(text);
        }
    }
}