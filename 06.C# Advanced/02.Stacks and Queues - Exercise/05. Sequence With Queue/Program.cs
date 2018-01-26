using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            queue.Enqueue(input);
            for (int i = 0; i < 50; i++)
            {
                var S = queue.Dequeue();
                Console.Write($"{S} ");
                queue.Enqueue(S+1);
                queue.Enqueue(S*2+1);
                queue.Enqueue(S + 2);
            }
        }
    }
}