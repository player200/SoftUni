using System;
using System.Collections.Generic;
using System.Linq;
namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();
            string options = Console.ReadLine();
            Func<List<string>, string, List<string>> strsWDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].StartsWith(s))
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, string, List<string>> strsWRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].StartsWith(s))
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };
            Func<List<string>, string, List<string>> endsWDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].EndsWith(s))
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, string, List<string>> endsWRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].EndsWith(s))
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };

            Func<List<string>, int, List<string>> lengthDouble = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Length <= s)
                    {
                        w.Insert(i, w[i]);
                        i++;
                    }
                }

                return w;
            };

            Func<List<string>, int, List<string>> lengthRemove = (w, s) =>
            {
                for (int i = 0; i < w.Count; i++)
                {
                    if (w[i].Length <= s)
                    {
                        w.Remove(w[i]);
                        i--;
                    }
                }

                return w;
            };
            while (options!= "Party!")
            {
                string[]tokens= options.Split();
                string optionality = tokens[0];
                string typeOfComand = tokens[1];
                string indexer = tokens[2];

                if (optionality== "Remove")
                {
                    switch (typeOfComand)
                    {
                        case "StartsWith":
                            names = strsWRemove(names, indexer);
                            break;

                        case "EndsWith":
                            names = endsWRemove(names, indexer);
                            break;

                        case "Length":
                            names = lengthRemove(names, int.Parse(indexer));
                            break;
                    }
                }
                else if (optionality == "Double")
                {
                    switch (typeOfComand)
                    {
                        case "StartsWith":
                            names = strsWDouble(names, indexer);
                            break;

                        case "EndsWith":
                            names = endsWDouble(names, indexer);
                            break;

                        case "Length":
                            names = lengthDouble(names, int.Parse(indexer));
                            break;
                    }
                }
                
                options = Console.ReadLine();
            }
            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}