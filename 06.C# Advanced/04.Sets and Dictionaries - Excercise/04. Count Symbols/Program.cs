using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().ToArray();
            var dictionary = new SortedDictionary<char,int>();
            foreach (var item in input)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 1);
                }
                else
                {
                    dictionary[item]++;
                }
            }
            foreach (var chars in dictionary)
            {
                Console.WriteLine($"{chars.Key}: {chars.Value} time/s");
            }
        }
    }
}