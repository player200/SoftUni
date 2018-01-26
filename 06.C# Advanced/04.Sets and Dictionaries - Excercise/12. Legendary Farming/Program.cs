using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Legendary_Farming
{
    class Program
    {
        static void Main()
        {
            var items = new Dictionary<string, string>();
            var remainingMaterials = new Dictionary<string, int>();
            var otherMaterials = new Dictionary<string, int>();
            var winner = string.Empty;

            items.Add("shards", "Shadowmourne");
            items.Add("fragments", "Valanyr");
            items.Add("motes", "Dragonwrath");

            remainingMaterials.Add("shards", 0);
            remainingMaterials.Add("fragments", 0);
            remainingMaterials.Add("motes", 0);

            while (winner == string.Empty)
            {
                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split(' ');

                for (int i = 0; i < tokens.Length; i++)
                {
                    var quantity = int.Parse(tokens[i]);
                    var material = tokens[++i];

                    switch (material)
                    {
                        case "shards":
                        case "fragments":
                        case "motes":
                            {
                                remainingMaterials[material] += quantity;

                                if (winner == string.Empty && remainingMaterials[material] >= 250)
                                {
                                    winner = material;
                                    remainingMaterials[material] -= 250;
                                }

                                break;
                            }
                        default:
                            {
                                if (otherMaterials.ContainsKey(material))
                                {
                                    otherMaterials[material] += quantity;
                                }
                                else
                                {
                                    otherMaterials.Add(material, quantity);
                                }

                                break;
                            }
                    }

                    if (winner != string.Empty)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"{items[winner]} obtained!");

            foreach (var material in remainingMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in otherMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}