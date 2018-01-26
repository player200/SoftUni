using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main()
        {
            int querie = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumber = new Stack<int>();
            var maxValue = int.MinValue;
            for (int i = 0; i < querie; i++)
            {
                var queries = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                if (queries[0]==1)
                {
                    stack.Push(queries[1]);
                    if (maxValue<queries[1])
                    {
                        maxValue =queries[1];
                        maxNumber.Push(maxValue);
                    }
                }
                else if (queries[0]==2)
                {
                    if (stack.Pop() == maxValue)
                    {
                        maxNumber.Pop();
                        if (maxNumber.Count!=0)
                        {
                            maxValue = maxNumber.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (queries[0]==3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}