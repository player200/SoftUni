using System;
using System.Collections.Generic;

class DragonArmy
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dragonTypes = new Dictionary<string, SortedDictionary<string, int[]>>();

        for (int i = 0; i < n; ++i)
        {
            var tokens = Console.ReadLine().Split(' ');
            var type = tokens[0];
            var name = tokens[1];
            int damage = 0,
                health = 0,
                armor = 0;

            if (!int.TryParse(tokens[2], out damage))
            {
                damage = 45;
            };

            if (!int.TryParse(tokens[3], out health))
            {
                health = 250;
            };

            if (!int.TryParse(tokens[4], out armor))
            {
                armor = 10;
            };

            if (dragonTypes.ContainsKey(type))
            {
                if (dragonTypes[type].ContainsKey(name))
                {
                    dragonTypes[type][name][0] = damage;
                    dragonTypes[type][name][1] = health;
                    dragonTypes[type][name][2] = armor;
                }
                else
                {
                    dragonTypes[type].Add(name, new int[] { damage, health, armor });
                }
            }
            else
            {
                var dragonNames = new SortedDictionary<string, int[]>();
                dragonNames.Add(name, new int[] { damage, health, armor });
                dragonTypes.Add(type, dragonNames);
            }
        }

        foreach (var pair in dragonTypes)
        {
            var type = pair.Key;
            var dragons = pair.Value;

            double avarageDamage = 0;
            double avarageHealth = 0;
            double avarageArmor = 0;

            foreach (var dragonInfo in dragons.Values)
            {
                avarageDamage += dragonInfo[0];
                avarageHealth += dragonInfo[1];
                avarageArmor += dragonInfo[2];
            }

            avarageDamage /= dragons.Count;
            avarageHealth /= dragons.Count;
            avarageArmor /= dragons.Count;

            Console.WriteLine(String.Format("{0}::({1:f2}/{2:f2}/{3:f2})", type, avarageDamage, avarageHealth, avarageArmor));

            foreach (var nestedPair in dragons)
            {
                var name = nestedPair.Key;
                var info = nestedPair.Value;

                Console.WriteLine($"-{name} -> damage: {info[0]}, health: {info[1]}, armor: {info[2]}");
            }
        }
    }
}