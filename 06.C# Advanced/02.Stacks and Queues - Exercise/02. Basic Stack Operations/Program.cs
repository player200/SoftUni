using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] inputSecondLine = Console.ReadLine().Split(' ');
            var stack = new Stack<int>();
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(inputSecondLine[i]));
            }
            for (int J = 0; J < s; J++)
            {
                stack.Pop();
            }
            int count = stack.Count();
            bool isExist = stack.Contains(x);
            int smaller = int.MaxValue;
            while (stack.Count!=0)
            {
                int pop = stack.Pop();
                if (smaller>pop)
                {
                    smaller = pop;
                }
            }
            if (count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (isExist)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(smaller);
                }
            }
        }
    }
}