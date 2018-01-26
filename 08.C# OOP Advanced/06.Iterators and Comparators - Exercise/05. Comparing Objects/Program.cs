using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            List<string> tokens = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
        }
        int n = int.Parse(Console.ReadLine());
        Person specialPerson = people[n-1];
        if (people.Where(x => x.CompareTo(specialPerson) == 0).Count() > 1)
        {
            int equal = people
                .Where(p => p.CompareTo(specialPerson) == 0).Count();
            int unequal = people
                .Where(p => p.CompareTo(specialPerson) != 0).Count();
            Console.WriteLine($"{equal} {unequal} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}