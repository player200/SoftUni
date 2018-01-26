using System;
using System.Text;
namespace _01.Reverse_String
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            for (int i = text.Length - 1; i >= 0; i--)
            {
                builder.Append(text[i]);
            }
            Console.WriteLine(builder);
        }
    }
}