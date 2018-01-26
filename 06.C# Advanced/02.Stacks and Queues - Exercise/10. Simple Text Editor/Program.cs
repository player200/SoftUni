using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            stack.Push(string.Empty);

            for (int i = 0; i < number; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int operation = int.Parse(tokens[0]);

                switch (operation)
                {
                    case 1:
                        {
                            string textAppend = tokens[1];
                            string update = stack.Peek() + textAppend;
                            stack.Push(update);
                            break;
                        }
                    case 2:
                        {
                            int count = int.Parse(tokens[1]);
                            string update = stack.Peek();
                            update = update.Remove(update.Length - count);
                            stack.Push(update);
                            break;
                        }
                    case 3:
                        {
                            int index = int.Parse(tokens[1]);
                            string lastUpdate = stack.Peek();
                            Console.WriteLine(lastUpdate[index - 1]);
                            break;
                        }
                    case 4:
                        {
                            stack.Pop();
                            break;
                        }
                }
            }
        }
    }
}