using System;
using System.Linq;
namespace _06.Find_and_Sum_Integers
{
    class Program
    {
        static void Main()
        {
            var numbersFromText = Console.ReadLine()
                .Split()
                .Select(n => {
                    long value;
                    bool success = long.TryParse(n, out value);
                    return new { value, success };
                })
                .Where(b => b.success)
                .Select(x => x.value)
                .ToList();
            if (numbersFromText.Count==0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(numbersFromText.Sum());
            }
        }
    }
}