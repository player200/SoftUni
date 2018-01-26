using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(tokens[0], int.Parse(tokens[1]));
            sortedSet.Add(person);
            hashSet.Add(person);
        }
        Console.WriteLine($"{sortedSet.Count}{Environment.NewLine}{hashSet.Count}");
    }
}