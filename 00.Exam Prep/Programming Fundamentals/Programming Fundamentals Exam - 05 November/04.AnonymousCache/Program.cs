namespace _04.AnonymousCache
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> collector = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> catche = new Dictionary<string, Dictionary<string, long>>();
            string input;
            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                string[] tokens = input.Split();
                if (tokens.Length == 1)
                {
                    string set = tokens[0];
                    if (!collector.ContainsKey(set))
                    {
                        collector[set] = new Dictionary<string, long>();
                    }
                    if (catche.ContainsKey(set) && collector.ContainsKey(set))
                    {
                        foreach (var items in catche.Where(c => c.Key == set))
                        {
                            foreach (var item in items.Value)
                            {
                                collector[set][item.Key] = item.Value;
                            }
                        }
                    }
                }
                else
                {
                    string key = tokens[0];
                    long value = long.Parse(tokens[2]);
                    string set = tokens[4];

                    if (!collector.ContainsKey(set))
                    {
                        if (!catche.ContainsKey(set))
                        {
                            catche[set] = new Dictionary<string, long>();
                        }
                        catche[set][key] = value;
                    }
                    else
                    {
                        collector[set][key] = value;
                    }
                }
            }

            if (collector.Count != 0)
            {
                var result = collector
                    .Select(c => new
                    {
                        Set = c.Key,
                        Keys = c.Value.Keys.ToList(),
                        Size = c.Value.Values.Sum()
                    })
                    .OrderByDescending(c => c.Size)
                    .FirstOrDefault();

                Console.WriteLine($"Data Set: {result.Set}, Total Size: {result.Size}");
                foreach (var item in result.Keys)
                {
                    Console.WriteLine($"$.{item}");
                }
            }
        }
    }
}