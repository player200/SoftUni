using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.Lego_Blocks
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[][] firstArray = new int[number][];
            int[][] secondArray = new int[number][];
            for (int i = 0; i < number; i++)
            {
                firstArray[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < number; i++)
            {
                secondArray[i] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
            }

            int comparator = firstArray[0].Length + secondArray[0].Length;
            bool fit = true;

            for (int i = 0; i < number - 1; i++)
            {
                if (firstArray[i].Length + secondArray[i].Length != firstArray[i + 1].Length + secondArray[i + 1].Length)
                {
                    fit = false;
                    break;
                }
            }

            if (fit)
            {
                PrintArrays(firstArray, secondArray);
            }
            else
            {
                var num = 0;
                for (int i = 0; i < number; i++)
                {
                    num += firstArray[i].Length + secondArray[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {num}");
            }
        }

        private static void PrintArrays(int[][] firstArray, int[][] secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                List<int> items = new List<int>();
                items.AddRange(firstArray[i]);
                items.AddRange(secondArray[i]);
                Console.WriteLine($"[{string.Join(", ", items)}]");
            }
        }
    }
}