namespace _03.StarEnigma
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> collector = new Dictionary<string, List<string>>();

            collector["Attacked"] = new List<string>();
            collector["Destroyed"] = new List<string>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string currentLine = Console.ReadLine();

                string patterns = "[starSTAR]";

                int countOfPattern = Regex.Matches(currentLine, patterns).Count;

                string newMessage = string.Empty;

                foreach (var currentChar in currentLine)
                {
                    int charToAdd = (int)currentChar - countOfPattern;
                    newMessage += (char)charToAdd;
                }

                var totalPattern = @"@([a-zA-Z]+)[^@\->:!]*:([0-9]+)[^@\->:!]*!(A|D)![^@\->:!]*->([0-9]+)";
                var regexTotal = new Regex(totalPattern);

                string name = string.Empty;
                int population = 0;
                string type = string.Empty;
                int soldiersCount = 0;

                if (!regexTotal.IsMatch(newMessage))
                {
                    continue;
                }

                foreach (Match match in Regex.Matches(newMessage, totalPattern))
                {
                    name = match.Groups[1].ToString();
                    population = int.Parse(match.Groups[2].ToString());
                    type = match.Groups[3].ToString();
                    soldiersCount = int.Parse(match.Groups[4].ToString());
                }

                if (type == "A")
                {
                    collector["Attacked"].Add(name);
                }
                else
                {
                    collector["Destroyed"].Add(name);
                }
            }

            foreach (var key in collector)
            {
                Console.WriteLine($"{key.Key} planets: {key.Value.Count}");
                if (key.Value.Count > 0)
                {
                    foreach (var value in key.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"-> {value}");
                    }
                }
            }
        }
    }
}