using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();
        string inputLine;
        while ((inputLine=Console.ReadLine())!= "Tournament")
        {
            string[] tokens = inputLine.Split();
            string trainerName = tokens[0];
            string pokemonName = tokens[1];
            string pokemonElement = tokens[2];
            int pokemonHealth =int.Parse(tokens[3]);
            if (trainers.Any(t=>t.Name==trainerName))
            {
                Trainer trainer = trainers.FirstOrDefault(x=>x.Name==trainerName);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }
            else
            {
                trainers.Add(new Trainer(trainerName,0,new List<Pokemon>() {new Pokemon(pokemonName,pokemonElement,pokemonHealth) }));
            }
        }
        string type;
        while ((type=Console.ReadLine())!="End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x=>x.Element==type))
                {
                    trainer.Badges += 1;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
        foreach (var trainer in trainers.OrderByDescending(x=>x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}