using System;
using System.Linq;
namespace _01.Matrix_of_Palindromes
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[][] matrix = new string[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[input[1]];
                matrix[row][0] = $"{alphabet[row]}{alphabet[row]}{alphabet[row]}";

                for (int col = 1; col < matrix[row].Length; col++)
                {
                    int chars = matrix[row][col-1][1] + 1;
                    matrix[row][col] = $"{alphabet[row]}{(char)chars}{alphabet[row]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}