namespace _02.AnonymousThreasure
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

            string commands;
            while ((commands = Console.ReadLine()) != "3:1")
            {
                string[] tokens = commands
                    .Split();
                string command = tokens[0];

                if (command == "merge")
                {
                    int firstIndex = int.Parse(tokens[1]);
                    int secondIndex = int.Parse(tokens[2]);

                    if (firstIndex < 0)
                    {
                        firstIndex = 0;
                    }
                    if (firstIndex >= words.Count)
                    {
                        firstIndex = words.Count - 1;
                    }
                    if (secondIndex >= words.Count)
                    {
                        secondIndex = words.Count - 1;
                    }
                    if (secondIndex < 0)
                    {
                        secondIndex = 0;
                    }
                    if (secondIndex <= firstIndex)
                    {
                        continue;
                    }
                    else
                    {
                        List<int> indexToRemove = new List<int>();
                        for (int i = firstIndex + 1; i <= secondIndex; i++)
                        {
                            words[firstIndex] = words[firstIndex] + words[i];
                            indexToRemove.Add(i);
                        }

                        indexToRemove.Reverse();

                        foreach (var index in indexToRemove)
                        {
                            words.RemoveAt(index);
                        }
                    }
                }
                else if (command == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    string currentWord = words[index];

                    List<string> collector = new List<string>();
                    int num = currentWord.Length / partitions;
                    if (currentWord.Length - (partitions * num) > 0)
                    {
                        for (int i = 0; i < partitions; i++)
                        {
                            if (i == partitions - 1)
                            {
                                string wordToAdd = currentWord.Substring(i * num);
                                collector.Add(wordToAdd);
                            }
                            else
                            {
                                string wordToAdd = currentWord.Substring(i * num, num);
                                collector.Add(wordToAdd);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < partitions; i++)
                        {
                            string wordToAdd = currentWord.Substring(i * num, num);
                            collector.Add(wordToAdd);
                        }
                    }

                    words.RemoveAt(index);

                    words.InsertRange(index, collector);

                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}