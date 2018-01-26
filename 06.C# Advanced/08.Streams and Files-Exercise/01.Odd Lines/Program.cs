using System;
using System.IO;
namespace _01.Odd_Lines
{
    class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../text.txt"))
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (lineNumber%2!=0)
                    {
                        Console.WriteLine("{0}: {1}", lineNumber, line);
                    }
                }
            }
        }
    }
}