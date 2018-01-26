using System;
namespace _02.String_Length
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            if (text.Length>20)
            {
                text = text.Substring(0,20);
                Console.WriteLine(text);
            }
            else
            {
                text= text.PadRight(20, '*');
                Console.WriteLine(text);
            }
        }
    }
}