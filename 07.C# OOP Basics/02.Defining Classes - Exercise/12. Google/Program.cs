using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();
        string inputLine;
        while ((inputLine=Console.ReadLine())!="End")
        {
            string[] tokens = inputLine.Split();
            string personName = tokens[0];
            if(!people.Any(p => p.Name == personName))
            {
                people.Add(new Person(personName));
            }
            Person person = people.FirstOrDefault(p => p.Name == personName);

            string type = tokens[1];
            switch (type)
            {
                case "company":
                    string companyName = tokens[2];
                    string department = tokens[3];
                    decimal salary = decimal.Parse(tokens[4],CultureInfo.InvariantCulture);
                    Company company = new Company(companyName,department,salary);
                    person.Company = company;
                    break;
                case "pokemon":
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];
                    person.Pokemons.Add(new Pokemon(pokemonName,pokemonType));
                    break;
                case "parents":
                    string parentName = tokens[2];
                    string parentBirthday = tokens[3];
                    person.Parents.Add(new Parents(parentName, parentBirthday));
                    break;
                case "children":
                    string childName = tokens[2];
                    string childBirthday = tokens[3];
                    person.Children.Add(new Children(childName, childBirthday));
                    break;
                case "car":
                    string model = tokens[2];
                    int speed = int.Parse(tokens[3]);
                    Car cars = new Car(model,speed);
                    person.Car = cars;
                    break;
            }
        }
        string name = Console.ReadLine();

        var per = people.FirstOrDefault(x=>x.Name==name);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(name);
        sb.AppendLine($"Company:");
        if (per.Company != null)
        {
            sb.AppendLine($"{per.Company.Name} {per.Company.Department} {per.Company.Salary:F2}");
        }
        sb.AppendLine($"Car:");
        if (per.Car != null)
        {
            sb.AppendLine($"{per.Car.Model} {per.Car.Speed}");
        }
        sb.AppendLine($"Pokemon:");
        foreach (var poke in per.Pokemons)
        {
            sb.AppendLine($"{poke.Name} {poke.Type}");
        }
        sb.AppendLine($"Parents:");
        foreach (var p in per.Parents)
        {
            sb.AppendLine($"{p.Name} {p.Birthday}");
        }
        sb.AppendLine($"Children:");
        foreach (var c in per.Children)
        {
            sb.AppendLine($"{c.Name} {c.Birthday}");
        }
        Console.WriteLine(sb);
    }
}
