using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] reminder = input.Split(' ');
            var stack = new Stack<string>(reminder.Reverse());
            while (stack.Count>1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string op = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                if (op=="+")
                {
                    stack.Push((firstNumber+secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}