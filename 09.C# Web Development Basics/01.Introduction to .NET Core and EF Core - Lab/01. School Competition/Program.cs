namespace _01._School_Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> namePoints = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> nameCategories = new Dictionary<string, HashSet<string>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine.Split();
                string studentName = tokens[0];
                string category = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!namePoints.ContainsKey(studentName))
                {
                    namePoints.Add(studentName, points);
                }

                else if (namePoints.ContainsKey(studentName))
                {
                    namePoints[studentName] += points;
                }

                if (!nameCategories.ContainsKey(studentName))
                {
                    nameCategories.Add(studentName, new HashSet<string> { category });
                }

                else if (nameCategories.ContainsKey(studentName))
                {
                    nameCategories[studentName].Add(category);
                }

            }

            var result = namePoints
                .OrderByDescending(np => np.Value)
                .ThenBy(np => np.Key);

            foreach (var item in result)
            {
                var resultCategory = nameCategories[item.Key]
                    .OrderBy(nc => nc);
                string outPutCategory = string.Join(", ", resultCategory);

                Console.WriteLine($"{item.Key}: {item.Value} [{outPutCategory}]");
            }
        }
    }
}