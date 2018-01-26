using System;
using System.Linq;
namespace _07.Bounded_Numbers
{
    class Program
    {
        static void Main()
        {
            var rangeNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(r=>r)
                .ToArray();
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n=>n>=rangeNumbers[0]&&n<=rangeNumbers[1])
                .ToArray();
            if (numbers.Length!=0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}