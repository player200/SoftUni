using System;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            long[][] matrix = new long[number][];
            int currentWidth = 1;

            for (int row = 0; row < number; row++)
            {
                matrix[row] = new long[currentWidth];
                long[] currentRow = matrix[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;
                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length - 1; i++)
                    {
                        long[] previousRow = matrix[row - 1];
                        long prevoiousRowSum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = prevoiousRowSum;
                    }
                }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join(" ",row)}");
            }
        }
    }
}