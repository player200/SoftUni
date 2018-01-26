using System;
using System.Collections.Generic;
using System.Linq;
namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string options = Console.ReadLine();

            var endWords = new List<string>();
            var startWords = new List<string>();
            var lens = new List<int>();
            var containsWord = new List<string>();
            

            while (options != "Print")
            {
                var tokens = options.Split(';');

                var command = tokens[0];
                var type = tokens[1];
                var parameter = tokens[2];

                if (command == "Add filter")
                {
                    switch (type)
                    {
                        case "Starts with":
                            startWords.Add(parameter);
                            break;

                        case "Ends with":
                            endWords.Add(parameter);
                            break;

                        case "Length":
                            lens.Add(int.Parse(parameter));
                            break;

                        case "Contains":
                            containsWord.Add(parameter);
                            break;
                    }
                }
                else if (command == "Remove filter")
                {
                    switch (type)
                    {
                        case "Starts with":
                            startWords.Remove(parameter);
                            break;

                        case "Ends with":
                            endWords.Remove(parameter);
                            break;

                        case "Length":
                            lens.Remove(int.Parse(parameter));
                            break;

                        case "Contains":
                            containsWord.Remove(parameter);
                            break;
                    }
                }

                options = Console.ReadLine();
            }

            foreach (var word in startWords)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].StartsWith(word))
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }
            }

            foreach (var word in endWords)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].EndsWith(word))
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }
            }

            foreach (var number in lens)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Length <= number)
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }
            }

            foreach (var word in containsWord)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[i].Contains(word))
                    {
                        names.Remove(names[i]);
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}