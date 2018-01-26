using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        SortedSet<Person> first = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> second = new SortedSet<Person>(new AgeComparer());
        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines; i++)
        {
            List<string> tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Person person = new Person(tokens[0], int.Parse(tokens[1]));
            first.Add(person);
            second.Add(person);
        }
        if (first.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, first));
            Console.WriteLine(string.Join(Environment.NewLine, second));
        }
    }
}