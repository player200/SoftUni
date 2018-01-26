using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConverter
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (input==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input!=0)
                {
                    stack.Push(input%2);
                    input /= 2;
                }
            }
            while (stack.Count>0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}