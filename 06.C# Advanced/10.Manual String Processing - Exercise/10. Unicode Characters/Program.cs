using System;
using System.Text;
namespace _10.Unicode_Characters
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string result = string.Empty;
            byte[] ascii = Encoding.ASCII.GetBytes(input);
            foreach (Byte b in ascii)
            {
                result +="\\u00" +b.ToString("X").ToLower();
            }
            Console.WriteLine(result);
        }
    }
}