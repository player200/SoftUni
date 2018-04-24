namespace _04.Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Dwarf> collector = new List<Dwarf>();

            string inputToken;
            while ((inputToken = Console.ReadLine()) != "Once upon a time")
            {
                var tokens = inputToken
                    .Split(new[] {'<',':','>' },StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = tokens[0].Trim();
                string dwarfHatColor = tokens[1].Trim();
                int dwarfPhysics = int.Parse(tokens[2].Trim());

                Dwarf currentDwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);

                if (!collector.Any(x => x.Name == currentDwarf.Name && x.HatColor == currentDwarf.HatColor))
                {
                    collector.Add(currentDwarf);
                }
                else
                {
                    var lastBest = collector
                        .Where(x => x.Name == currentDwarf.Name)
                        .FirstOrDefault()
                        .Physics;

                    if (currentDwarf.Physics > lastBest)
                    {
                        var lastItem = collector
                            .Where(x => x.Name == currentDwarf.Name)
                            .FirstOrDefault();
                        collector.Remove(lastItem);

                        collector.Add(currentDwarf);
                    }
                }
            }

            foreach (var item in collector
                                    .OrderByDescending(x => x.Physics)
                                    .ThenByDescending(x => collector
                                                         .Where(y => y.HatColor == x.HatColor).Count()))
            {
                Console.WriteLine($"({item.HatColor}) {item.Name} <-> {item.Physics}");
            }
        }
    }

    class Dwarf
    {
        public Dwarf(string name, string hatColor, int physics)
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.Physics = physics;
        }

        public string Name { get; set; }

        public string HatColor { get; set; }

        public int Physics { get; set; }
    }
}