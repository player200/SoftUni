using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Target_Practice
{
    class Program
    {
        static void Main()
        {
            var matrixArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rowIndex = matrixArgs[0];
            int colIndex = matrixArgs[1];
            string snakeStr = Console.ReadLine();
            Queue<char> snake = new Queue<char>(snakeStr.ToCharArray());
            var shotArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int impactRow = shotArgs[0];
            int impactCol = shotArgs[1];
            int impactRadius = shotArgs[2];
            char[][] matrix = new char[rowIndex][];

            PopulateMatrix(snake, matrix, rowIndex, colIndex);
            NukeMatrix(matrix, impactRow, impactCol, impactRadius);
            ApplyGravity(matrix);
            PrintMatrix(matrix);
        }

        private static void ApplyGravity(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                Stack<char> currentCol = new Stack<char>();
                for (int row = 0; row < matrix.Length; row++)
                {
                    char currentChar = matrix[row][col];
                    if (currentChar != ' ')
                    {
                        currentCol.Push(currentChar);
                        matrix[row][col] = ' ';
                    }
                }

                for (int roww = matrix.Length - 1; roww >= 0; roww--)
                {
                    if (currentCol.Count > 0)
                    {
                        matrix[roww][col] = currentCol.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void NukeMatrix(char[][] matrix, int impactRow, int impactCol, int impactRadius)
        {
            if (impactRadius == 0)
            {
                matrix[impactRow][impactCol] = ' ';
                return;
            }
            else
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    for (int c = 0; c < matrix[0].Length; c++)
                    {
                        if (((r - impactRow) * (r - impactRow) + (c - impactCol) * (c - impactCol)) <= impactRadius * impactRadius)
                        {
                            matrix[r][c] = ' ';
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var arr in matrix)
            {
                Console.WriteLine(string.Join("", arr));
            }
        }

        private static void PopulateMatrix(Queue<char> snake, char[][] matrix, int row, int col)
        {
            var step = 1;
            for (int r = matrix.Length - 1; r >= 0; r--)
            {
                if (step % 2 == 0)
                {
                    var arr = new char[col];
                    for (int c = 0; c < arr.Length; c++)
                    {
                        char currentChar = snake.Dequeue();
                        arr[c] = currentChar;
                        snake.Enqueue(currentChar);
                    }
                    matrix[r] = arr;
                }
                else
                {
                    var arr = new char[col];
                    for (int c = arr.Length - 1; c >= 0; c--)
                    {
                        char currentChar = snake.Dequeue();
                        arr[c] = currentChar;
                        snake.Enqueue(currentChar);
                    }
                    matrix[r] = arr;
                }
                step++;
            }
        }
    }
}