using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    class Program
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, string>();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "search")
            {
                var splited = input.Split('-');
                var name = splited[0];
                var number = splited[1];

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name] = number;
                }
                else
                {
                    dictionary.Add(name, number);
                }
            }
            while ((input = Console.ReadLine()) != "stop")
            {
                if (dictionary.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {dictionary[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}