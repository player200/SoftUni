using System;
using System.Globalization;
namespace _03.Formatting_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine()
                .Split(new char[] {' ','\t' },StringSplitOptions.RemoveEmptyEntries);
            int firstNumber = int.Parse(inputNumbers[0]);
            double secondNumber = double.Parse(inputNumbers[1], CultureInfo.InvariantCulture);
            double thirdNumber = double.Parse(inputNumbers[2], CultureInfo.InvariantCulture);

            string binary = Convert.ToString(firstNumber, 2);
            if (binary.Length>10)
            {
                binary = binary.Substring(0,10);
            }
            else
            {
                binary = binary.PadLeft(10,'0');
            }
            Console.WriteLine("|{0,-10:X}|{1}|{2,10:f2}|{3,-10:f3}|",firstNumber,binary,secondNumber,thirdNumber);
        }
    }
}