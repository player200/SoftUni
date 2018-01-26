using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] days = new int[number];
            var stack = new Stack<int>();
            stack.Push(0);

            for (int i = 0; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                stack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}