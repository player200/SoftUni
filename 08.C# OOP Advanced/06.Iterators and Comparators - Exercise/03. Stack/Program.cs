using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();
        string inputLine;
        while ((inputLine=Console.ReadLine())!="END")
        {
            string[] tokens = inputLine.Split(new string[] {" ",", " },StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Pop":
                        stack.Pop();
                        break;
                    case "Push":
                        stack.Push(tokens.Skip(1).ToArray());
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        if (stack.Stacks.Count>0)
        {
            Console.WriteLine(stack.ToString());
        }
    }
}