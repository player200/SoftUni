using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string type = Console.ReadLine();
            Func<List<int>, List<int>> add = n=> n.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = n => n.Select(x => x *2).ToList();
            Func<List<int>, List<int>> subtract = n => n.Select(x => x -1).ToList();
            Action<List<int>> print =n=> Console.WriteLine(string.Join(" ",n));
            while (type!="end")
            {
                switch (type)
                {
                    case "add":
                        numbers = add(numbers);
                        break;

                    case "multiply":
                        numbers = multiply(numbers);
                        break;

                    case "subtract":
                        numbers = subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;
                }
                type = Console.ReadLine();
            }
        }
    }
}