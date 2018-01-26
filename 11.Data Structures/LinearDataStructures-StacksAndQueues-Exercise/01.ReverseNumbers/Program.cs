namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string inputTokens = Console.ReadLine();

            Stack<int> collector = new Stack<int>();

            int[] numbersToAdd = inputTokens
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                collector.Push(numbersToAdd[i]);
            }

            string outPutResult = string.Empty;
            while (collector.Count > 0)
            {
                outPutResult = outPutResult + " " + collector.Pop();

            }
            Console.WriteLine(outPutResult.Trim());
        }
    }
}