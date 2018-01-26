using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Balanced_Parenthesis
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>();
            char[] openCase = new char[] { '{', '[', '(' };
            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (openCase.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }
                    switch (input[i])
                    {
                        case '}':
                            if(stack.Pop() != '{')
                            {
                                isBalanced = false;
                            }
                            break;
                        case ']':
                            if(stack.Pop() != '[')
                            {
                                isBalanced = false;
                            }
                            break;
                        case ')':
                            if(stack.Pop() != '(')
                            {
                                isBalanced = false;
                            }
                            break;
                    }
                    if (!isBalanced)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}