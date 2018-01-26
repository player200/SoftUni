using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            people.Add(new Person(name, age));
        }
        foreach (var person in people.Where(x => x.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
