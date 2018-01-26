namespace _02.SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();

            Console.WriteLine(string.Join(" ",words.OrderBy(w=>w)).Trim());
        }
    }
}