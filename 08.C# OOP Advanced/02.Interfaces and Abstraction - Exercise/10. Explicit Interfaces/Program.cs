using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        string input = string.Empty;
        ICollection<Citizen> people = new List<Citizen>();
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            people.Add(new Citizen(tokens[0], tokens[1], int.Parse(tokens[2])));
        }
        foreach (var person in people)
        {
            Console.WriteLine((person as IPerson).GetName());
            Console.WriteLine((person as IResident).GetName());
        }
    }
}