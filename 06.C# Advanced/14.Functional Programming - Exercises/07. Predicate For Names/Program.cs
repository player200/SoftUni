using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();
            Func<List<string>, List<string>> printer = t => t.Where(x => x.Length <= lenght).ToList();
            foreach (var name in printer(names))
            {
                Console.WriteLine(name);
            }
        }
    }
}