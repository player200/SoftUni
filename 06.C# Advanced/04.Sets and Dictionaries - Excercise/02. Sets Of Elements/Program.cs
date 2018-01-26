using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sets_Of_Elements
{
    class Program
    {
        static void Main()
        {
            //var tokens = Console.ReadLine()
            //.Split(' ')
            //.Select(int.Parse)
            //.ToArray();
            //var firstSet = new HashSet<int>();
            //var secondSet = new HashSet<int>();
            //
            //for (int i = 0; i < tokens[0]; i++)
            //{
            //    var number = int.Parse(Console.ReadLine());
            //    firstSet.Add(number);
            //}
            //
            //for (int i = 0; i < tokens[1]; i++)
            //{
            //    var number = int.Parse(Console.ReadLine());
            //    secondSet.Add(number);
            //}
            //
            //foreach (var item in firstSet)
            //{
            //    if (secondSet.Contains(item))
            //    {
            //        Console.Write(item + " ");
            //    }
            //}
            //Console.WriteLine();

            string input = Console.ReadLine();
            var setAllIn = new HashSet<int>();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var token = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n=>int.Parse(n))
                .ToArray();
            int allElements = token[0] + token[1];
            while (allElements> token[0])
            {
                int inputTokens = int.Parse(Console.ReadLine());
                firstSet.Add(inputTokens);
                allElements--;
            }
            while (allElements!=0)
            {
                int inputTokens = int.Parse(Console.ReadLine());
                secondSet.Add(inputTokens);
                if (secondSet.Contains(inputTokens)==firstSet.Contains(inputTokens))
                {
                    setAllIn.Add(inputTokens);
                    foreach (var item in setAllIn)
                    {
                        Console.WriteLine(item);
                    }
                }
                allElements--;
            }
        }
    }
}