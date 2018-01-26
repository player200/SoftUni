using System;
namespace _01.Action_Print
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split();
            Action<string> action = str => Console.WriteLine(str);
            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}