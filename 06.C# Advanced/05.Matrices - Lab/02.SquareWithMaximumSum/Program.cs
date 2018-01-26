using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            var startedSum = int.MinValue;
            var maxSqureRow = 0;
            var maxSqureCol = 0;

            for (int row = 0; row < matrix.Length-1; row++)
            {
                for (int col = 0; col < matrix[row].Length-1; col++)
                {
                    var squereSum =matrix[row][col]+matrix[row][col+1]
                        +matrix[row+1][col]+matrix[row+1][col+1];
                    if (startedSum<squereSum)
                    {
                        startedSum = squereSum;
                        maxSqureRow = row;
                        maxSqureCol = col;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxSqureRow][maxSqureCol]} {matrix[maxSqureRow][maxSqureCol+1]}");
            Console.WriteLine($"{matrix[maxSqureRow + 1][maxSqureCol]} {matrix[maxSqureRow+1][maxSqureCol+1]}");
            Console.WriteLine(startedSum);
        }
    }
}