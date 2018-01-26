namespace _01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            int[] numbersRange = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Thread events = new Thread(() => PrintEvenNumbers(numbersRange[0], numbersRange[1]));
            events.Start();
            events.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}