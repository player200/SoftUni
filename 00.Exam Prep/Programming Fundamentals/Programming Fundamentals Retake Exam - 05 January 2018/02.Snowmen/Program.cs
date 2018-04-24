namespace _02.Snowmen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToList();
            HashSet<int> indexOfLosers = new HashSet<int>();
            
            while (numbers.Count > 1)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (Math.Abs(numbers.Count - indexOfLosers.Count) == 1)
                    {
                        continue;
                    }
            
                    if (indexOfLosers.Contains(i))
                    {
                        continue;
                    }
            
                    var attacker = i;
                    var target = ValidIndex(numbers[i], numbers.Count);
                    var result = Math.Abs(attacker - target);
            
                    if (result == 0)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        indexOfLosers.Add(attacker);
                    }
            
                    if (result != 0 && result % 2 == 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        indexOfLosers.Add(target);
                    }
                    else if (result % 2 != 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        indexOfLosers.Add(attacker);
                    }
                }
            
                foreach (var item in indexOfLosers.OrderByDescending(x => x))
                {
                    numbers.RemoveAt(item);
                }
                indexOfLosers.Clear();
            }
        }

        private static int ValidIndex(int index, int lenght)
        {
            if (index >= lenght)
            {
                index = index % lenght;
            }

            return index;
        }
    }
}