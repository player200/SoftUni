using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var dictionary = new SortedDictionary<string,List<double>>();
            while (number!=0)
            {
                string name = Console.ReadLine();
                var marks = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(n=>double.Parse(n,CultureInfo.InvariantCulture))
                    .ToList();
                dictionary.Add(name,marks);
                number--;
            }
            foreach (var studentAvarage in dictionary)
            {
                Console.WriteLine($"{studentAvarage.Key} is graduated with {studentAvarage.Value.Average()}");
            }
        }
    }
}