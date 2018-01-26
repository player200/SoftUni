using System;
using System.Linq;
namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine().Split(new string[] { " " },
                 StringSplitOptions.RemoveEmptyEntries);
            
            words.Where(n => n[0] == n.ToUpper()[0])
                 .ToList()
                 .ForEach(n => Console.WriteLine(n));
        }
    }
}