using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main()
    {
        ICollection<ISociety> society = new List<ISociety>();
        string inputLine;
        while ((inputLine=Console.ReadLine())!="End")
        {
            var tokens = inputLine.Split();
            if (tokens.Length == 3)
            {
                society.Add(new Citizens(tokens[0],int.Parse(tokens[1]),tokens[2]));
            }
            else
            {
                society.Add(new Robots(tokens[0], tokens[1]));
            }
        }
        string id = Console.ReadLine();

        if (society.Any(x=>x.Id.EndsWith(id)))
        {
            var sb = new StringBuilder();
            foreach (var collector in society.Where(x=>x.Id.EndsWith(id)))
            {
                sb.AppendLine($"{collector.Id}");
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}