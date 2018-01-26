using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var circle = new Queue<long[]>();

            for (int i = 0; i < n; i++)
            {
                long[] tokens = Console.ReadLine()
                    .Split(' ')
                    .Select(long.Parse)
                    .ToArray();
                circle.Enqueue(tokens);
            }

            int startIndex = 0;
            long tankFuel = 0;

            for (; startIndex < circle.Count; ++startIndex)
            {
                bool shouldBreak = true;
                long[] currentPump = circle.Dequeue();
                circle.Enqueue(currentPump);
                tankFuel = currentPump[0] - currentPump[1];

                if (tankFuel < 0)
                {
                    continue;
                }

                for (int itteration = 0; itteration < circle.Count; itteration++)
                {
                    currentPump = circle.Dequeue();
                    circle.Enqueue(currentPump);
                    tankFuel += currentPump[0];
                    tankFuel -= currentPump[1];

                    if (tankFuel < 0)
                    {
                        shouldBreak = false;
                    }
                }

                if (shouldBreak)
                {
                    break;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}