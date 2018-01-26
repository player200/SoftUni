using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _03.CountSameValuesInArray
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var inputTokens = input.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new SortedDictionary<double,int>();
            foreach (var tokens in inputTokens)
            {
                double remainder = double.Parse(tokens,CultureInfo.InvariantCulture);
                if (!dictionary.ContainsKey(remainder))
                {
                    dictionary.Add(remainder, 1);
                }
                else
                {
                    dictionary[remainder]++;
                }
            }
            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}