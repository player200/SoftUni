using System;
namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);
            Action<string> printer = str => Console.WriteLine("Sir "+str);
            foreach (var name in names)
            {
                printer(name);
            }
        }
    }
}