namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> printer = new List<int>();
            List<int> secondPrinter = new List<int>();
            printer.Add(numbers[0]);
            for (int i = 1; i < numbers.Count - 1; i++)
            {
                if (printer.LastOrDefault() == numbers[i] && numbers[i - 1] == numbers[i])
                {
                    printer.Add(numbers[i]);
                }
                else
                {
                    if (secondPrinter.Count == 0)
                    {
                        secondPrinter.Add(numbers[i]);
                    }
                    else if (secondPrinter.LastOrDefault() == numbers[i] && numbers[i - 1] == numbers[i])
                    {
                        secondPrinter.Add(numbers[i]);
                    }
                    else if (secondPrinter.LastOrDefault() != numbers[i] && numbers[i - 1] != numbers[i])
                    {
                        if (printer.Count() < secondPrinter.Count())
                        {
                            printer.Clear();
                            foreach (var item in secondPrinter)
                            {
                                printer.Add(item);
                            }
                            secondPrinter.Clear();
                            if (secondPrinter.Count == 0)
                            {
                                secondPrinter.Add(numbers[i]);
                            }
                            else if (secondPrinter.LastOrDefault() == numbers[i] && numbers[i - 1] == numbers[i])
                            {
                                secondPrinter.Add(numbers[i]);
                            }
                        }
                        else
                        {
                            secondPrinter.Clear();
                            if (secondPrinter.Count == 0)
                            {
                                secondPrinter.Add(numbers[i]);
                            }
                            else if (secondPrinter.LastOrDefault() == numbers[i] && numbers[i - 1] == numbers[i])
                            {
                                secondPrinter.Add(numbers[i]);
                            }
                        }
                    }
                }
            }
            if (secondPrinter.LastOrDefault() == numbers.LastOrDefault())
            {
                secondPrinter.Add(numbers.LastOrDefault());
            }

            if (printer.Count() < secondPrinter.Count())
            {
                Console.WriteLine(string.Join(" ", secondPrinter).Trim());
            }
            else
            {
                Console.WriteLine(string.Join(" ", printer).Trim());
            }
        }
    }
}