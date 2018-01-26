using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            var stack = new Stack<ulong>(new ulong[] {0,1 });
            for (ulong i = 2; i <= number; i++)
            {
                ulong last = stack.Pop();
                ulong beforeLast = stack.Pop();
                ulong current = last + beforeLast;
                stack.Push(beforeLast);
                stack.Push(last);
                stack.Push(current);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}