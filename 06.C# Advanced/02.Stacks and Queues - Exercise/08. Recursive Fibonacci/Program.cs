using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        private static long[] fibNumbers;
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            fibNumbers = new long[number];
            var result = getFibonacci(number);
            Console.WriteLine(result);
        }
        private static long getFibonacci(int number)
        {
            if (number<=2)
            {
                return 1;
            }
            if (fibNumbers[number-1]!=0)
            {
                return fibNumbers[number - 1];
            }
            return fibNumbers[number-1]= getFibonacci(number-1)+getFibonacci(number-2);
        }
    }
}