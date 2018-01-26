using System;
using System.Linq;

namespace _01.SumOfAllElementsOfMatrix
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {", " },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] matrix = new int[input[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ", "},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            int sum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                sum += matrix[row].Sum();
            }
            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);
            Console.WriteLine(sum);
        }
    }
}