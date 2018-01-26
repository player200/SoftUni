using System;
using System.Linq;
namespace _02.Diagonal_Difference
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            long[][] matrix = new long[input][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }
            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            for (int i = 0; i < input; i++)
            {
                long firstNumber = matrix[i][i];
                long secondNumber = matrix[input-1-i][i];
                primaryDiagonal += firstNumber;
                secondaryDiagonal += secondNumber;
            }
            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }
    }
}