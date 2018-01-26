using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var set = new SortedSet<string>();
            for (int i =0; i < number; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input)
                {
                    set.Add(item);
                }
            }
            foreach (var item in set)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}