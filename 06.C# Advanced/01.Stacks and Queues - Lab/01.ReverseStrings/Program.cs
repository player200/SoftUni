using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}