using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] inputSecondLine = Console.ReadLine().Split(' ');
            var queue = new Queue<int>();
            int n = int.Parse(input[0]);
            int s = int.Parse(input[1]);
            int x = int.Parse(input[2]);
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(int.Parse(inputSecondLine[i]));
            }
            for (int J = 0; J < s; J++)
            {
                queue.Dequeue();
            }
            int count = queue.Count();
            bool isExist = queue.Contains(x);
            int smaller = int.MaxValue;
            while (queue.Count != 0)
            {
                int pop = queue.Dequeue();
                if (smaller > pop)
                {
                    smaller = pop;
                }
            }
            if (count == 0)
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