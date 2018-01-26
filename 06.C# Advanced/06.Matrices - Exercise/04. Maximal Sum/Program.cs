using System;
using System.Linq;
namespace _04.Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            var startedSum = int.MinValue;
            var maxSqureRow = 0;
            var maxSqureCol = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    var firstIndex = matrix[row][col];
                    var secondIndex = matrix[row][col + 1];
                    var thirdIndex = matrix[row][col + 2];

                    var fourthIndex = matrix[row + 1][col];
                    var fifthIndex = matrix[row + 1][col + 1];
                    var sixthIndex = matrix[row + 1][col + 2];
                    
                    var seventhIndex = matrix[row + 2][col];
                    var eighthIndex = matrix[row + 2][col + 1];
                    var ninethIndex = matrix[row + 2][col + 2];

                    var squereSum = firstIndex + secondIndex + thirdIndex
                        + fourthIndex + fifthIndex + sixthIndex
                        + seventhIndex + eighthIndex + ninethIndex;
                    if (startedSum < squereSum)
                    {
                        startedSum = squereSum;
                        maxSqureRow = row;
                        maxSqureCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {startedSum}");
            Console.WriteLine($"{matrix[maxSqureRow][maxSqureCol]} {matrix[maxSqureRow][maxSqureCol + 1]} {matrix[maxSqureRow][maxSqureCol + 2]}");
            Console.WriteLine($"{matrix[maxSqureRow + 1][maxSqureCol]} {matrix[maxSqureRow + 1][maxSqureCol + 1]} {matrix[maxSqureRow+1][maxSqureCol + 2]}");
            Console.WriteLine($"{matrix[maxSqureRow + 2][maxSqureCol]} {matrix[maxSqureRow + 2][maxSqureCol + 1]} {matrix[maxSqureRow+2][maxSqureCol + 2]}");
        }
    }
}