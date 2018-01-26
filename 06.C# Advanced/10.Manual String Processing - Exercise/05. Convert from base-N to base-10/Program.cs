using System;
using System.Numerics;
namespace _05.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(' ');
            int firstNumber = int.Parse(inputNumbers[0]);
            BigInteger result = 0;
            int degree = 0;
            for (int i = inputNumbers[1].Length - 1; i >= 0; i--)
            {
                result += int.Parse(inputNumbers[1][i].ToString())
                    * BigInteger.Pow(firstNumber, degree);
                degree++;
            }
            Console.WriteLine(result);
        }
    }
}