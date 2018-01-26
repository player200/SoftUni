using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main()
    {
        ICollection<IBirthable> birthDay = new List<IBirthable>();
        ICollection<ISociety> society = new List<ISociety>();
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var tokens = inputLine.Split();
            switch (tokens[0])
            {
                case "Citizen":
                    birthDay.Add(new Citizens(tokens[1],int.Parse(tokens[2]),tokens[3],tokens[4]));
                    break;
                case "Robot":
                    society.Add(new Robots(tokens[1],tokens[2]));
                    break;
                case "Pet":
                    birthDay.Add(new Pet(tokens[1],tokens[2]));
                    break;
                default:
                    break;
            }
        }
        string year = Console.ReadLine();

        if (birthDay.Any(x => x.BirthDay.EndsWith(year)))
        {
            var sb = new StringBuilder();
            foreach (var collector in birthDay.Where(x => x.BirthDay.EndsWith(year)))
            {
                sb.AppendLine($"{collector.BirthDay}");
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}