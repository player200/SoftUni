using System;
using System.Text;
namespace _05.Concatenate_Strings
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();
            string input = string.Empty;
            for (int i = 0; i < number; i++)
            {
                input = Console.ReadLine();
                builder.Append(input+" ");
            }
            Console.WriteLine(builder);
        }
    }
}