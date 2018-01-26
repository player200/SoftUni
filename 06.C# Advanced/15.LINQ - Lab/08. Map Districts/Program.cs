using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.Map_Districts
{
    class Program
    {
        static void Main()
        {
            string[] inputMaping = Console.ReadLine()
                .Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);
            long minPopulation = long.Parse(Console.ReadLine());
            Dictionary<string, List<long>> mapper = new Dictionary<string,List<long>>();
            for (int i = 0; i < inputMaping.Length; i++)
            {
                string[] cityTokens = inputMaping[i]
                    .Split(new[] {':' },StringSplitOptions.RemoveEmptyEntries);
                string cityName = cityTokens[0];
                long population = long.Parse(cityTokens[1]);
                if (mapper.ContainsKey(cityName))
                {
                    mapper[cityName].Add(population);
                }
                else
                {
                    mapper.Add(cityName,new List<long>() { population });
                }
            }
            mapper = mapper
                .Where(t => t.Value.Sum() > minPopulation)
                .OrderByDescending(t => t.Value.Sum())
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var city in mapper)
            {
                Console.WriteLine(string.Format("{0}: {1}", 
                    city.Key,
                    string.Join(" ", city.Value.OrderByDescending(v => v).Take(5))));
            }
        }
    }
}