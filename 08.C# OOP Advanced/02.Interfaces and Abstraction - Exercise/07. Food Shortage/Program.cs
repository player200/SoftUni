using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        ICollection<IPerson> person = new List<IPerson>();
        int numberOfNames = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfNames; i++)
        {
            var tokens = Console.ReadLine().Split();
            if (tokens.Length == 4)
            {
                person.Add(new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
            }
            else if (tokens.Length == 3)
            {
                person.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
        }
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            if (person.Any(x => x.Name == inputLine))
            {
                var per = person.First(x=>x.Name== inputLine);
                per.BuyFood();
            }
        }
        Console.WriteLine(person.Sum(x=>x.Food));
    }
}