using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var populationCounter = new Dictionary<string,Dictionary<string,long>>();
            while (input!= "report")
            {
                var tokens = input.Split(new[] { '|'},StringSplitOptions.RemoveEmptyEntries);
                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);
                if (populationCounter.ContainsKey(country))
                {
                    populationCounter[country][city] = population;
                }
                else
                {
                    populationCounter[country] = new Dictionary<string, long>() { { city, population } };
                }

                input = Console.ReadLine();
            }

            var allPopulation = populationCounter
                .OrderByDescending(x=>x.Value.Values.Sum())
                .ToDictionary(e=>e.Key,e=>e.Value);

            foreach (var popul in allPopulation)
            {
                var order = popul.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(e=>e.Key,e=>e.Value);
                Console.WriteLine($"{popul.Key} (total population: {popul.Value.Values.Sum()})");
                foreach (var country in order)
                {
                    Console.WriteLine($"=>{country.Key}: {country.Value}");
                }
            }
        }
    }
}