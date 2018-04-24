namespace _04.ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            HashSet<string> uniqueUsers = new HashSet<string>();
            Dictionary<string, List<string>> collector = new Dictionary<string, List<string>>();

            string inputToken;
            while ((inputToken = Console.ReadLine()) != "Lumpawaroo")
            {
                string forceSide;
                string forceUser;

                if (inputToken.Contains(" | "))
                {
                    inputToken = inputToken.Replace(" | ", ";");
                    string[] tokens = inputToken
                        .Split(';');

                    forceSide = tokens[0];
                    forceUser = tokens[1];

                    if (!uniqueUsers.Contains(forceUser))
                    {
                        uniqueUsers.Add(forceUser);
                        if (!collector.ContainsKey(forceSide))
                        {
                            collector[forceSide] = new List<string>();
                        }

                        collector[forceSide].Add(forceUser);
                    }
                }
                else if (inputToken.Contains(" -> "))
                {
                    inputToken = inputToken.Replace(" -> ", ";");
                    string[] tokens = inputToken
                        .Split(';');

                    forceSide = tokens[1];
                    forceUser = tokens[0];

                    if (uniqueUsers.Contains(forceUser))
                    {
                        var firstSide = collector
                            .Where(x => x.Value.Contains(forceUser))
                            .FirstOrDefault()
                            .Key;

                        if (!collector.ContainsKey(forceSide))
                        {
                            collector[forceSide] = new List<string>();
                        }

                        collector[forceSide].Add(forceUser);
                        collector[firstSide].Remove(forceUser);

                        Console.WriteLine($"{forceSide} joins the {forceUser} side!");
                    }
                    else
                    {
                        uniqueUsers.Add(forceUser);
                        if (!collector.ContainsKey(forceSide))
                        {
                            collector[forceSide] = new List<string>();
                        }

                        collector[forceSide].Add(forceUser);

                        Console.WriteLine($"{forceSide} joins the {forceUser} side!");
                    }
                }
            }
            
            foreach (var key in collector
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                if (key.Value.Count!=0)
                {
                    Console.WriteLine($"Side: {key.Key}, Members: {key.Value.Count}");
                    foreach (var value in key.Value.OrderBy(x=>x))
                    {
                        Console.WriteLine($"! {value}");
                    }
                }
            }
        }
    }
}