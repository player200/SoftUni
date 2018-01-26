using System;
namespace _07.Sum_big_numbers
{
    class Program
    {
        static void Main()
        {
            string firstNumber = Console.ReadLine().TrimStart(new Char[] { '0' });
            string secondNumber = Console.ReadLine().TrimStart(new Char[] { '0' });
            string result = string.Empty;
            int remainder = 0;
            for (int firstNumberIndex = firstNumber.Length - 1, secondNumberIndex = secondNumber.Length - 1;
            firstNumberIndex >= 0 || secondNumberIndex >= 0 || remainder > 0;
            firstNumberIndex--, secondNumberIndex--)
            {
                int firstNumberDigit = firstNumberIndex >= 0 ? int.Parse(firstNumber[firstNumberIndex].ToString()) : 0;
                int secondNumberDigit = secondNumberIndex >= 0 ? int.Parse(secondNumber[secondNumberIndex].ToString()) : 0;
                int addDigit = firstNumberDigit + secondNumberDigit + remainder;

                if (addDigit > 9)
                {
                    remainder = addDigit / 10;
                    addDigit = addDigit % 10;
                }
                else
                {
                    remainder = 0;
                }

                result = addDigit + result;
            }
            Console.WriteLine(result);
        }
    }
}