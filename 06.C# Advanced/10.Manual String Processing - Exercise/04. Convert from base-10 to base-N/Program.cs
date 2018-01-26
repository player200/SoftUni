using System;
using System.Numerics;
namespace _04.Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main()
        {
            string[] inputNumbers = Console.ReadLine().Split(' ');
            BigInteger firstNumber = BigInteger.Parse(inputNumbers[0]);
            BigInteger secondNumber = BigInteger.Parse(inputNumbers[1]);
            BigInteger remainder;
            string result = string.Empty;
            if (firstNumber >= 2 && firstNumber <= 10)
            {
                while (secondNumber > 0)
                {
                    remainder = secondNumber % firstNumber;
                    secondNumber /= firstNumber;
                    result = remainder.ToString() + result;
                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}