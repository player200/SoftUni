using System;
using System.Linq;
namespace _03.Squares_in_Matrix
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new [] {' ' },StringSplitOptions.RemoveEmptyEntries )
                .Select(int.Parse)
                .ToArray();
            char[][] matrix = new char[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] {' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
            int squereCounter = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var firstIndex = matrix[row][col];
                    var secondIndex = matrix[row][col + 1];
                    var thirdIndex = matrix[row + 1][col];
                    var fourthIndex = matrix[row + 1][col + 1];
                    if ((firstIndex == secondIndex) && (thirdIndex == fourthIndex) &&(firstIndex == thirdIndex) &&(secondIndex==fourthIndex))
                    {
                        squereCounter++;
                    }
                }
            }
            Console.WriteLine(squereCounter);
        }
    }
}