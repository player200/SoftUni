using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", "},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] size = new int[3];

            foreach (var number in input)
            {
                int reminder = Math.Abs(number%3);
                size[reminder]++;
            }

            int[][] matrix = new int[3][] 
            {
                new int[size[0]],
                new int[size[1]],
                new int[size[2]]
            };
            int[] offSet = new int[3];

            foreach (var number in input)
            {
                var reminder = Math.Abs(number)% 3;
                int index= offSet[reminder];
                offSet[reminder]++;
                matrix[reminder][index] = number;
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }



            //var zero = input.Where(a=> Math.Abs(a) % 3==0).ToArray();
            //var one = input.Where(a =>Math.Abs(a)% 3 == 1 ).ToArray();
            //var two = input.Where(a => Math.Abs(a) % 3 == 2).ToArray();
            //Console.WriteLine(string.Join(" ",zero));
            //Console.WriteLine(string.Join(" ", one));
            //Console.WriteLine(string.Join(" ", two));
        }
    }
}