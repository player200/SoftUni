using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<char, int> collector = new Dictionary<char, int>();

        string inputToken = Console.ReadLine();

        for (int i = 0; i < inputToken.Length; i++)
        {
            if (!collector.ContainsKey(inputToken[i]))
            {
                collector.Add(inputToken[i],0);
            }

            collector[inputToken[i]] ++;
        }

        foreach (var order in collector.OrderBy(c=>c.Key))
        {
            Console.WriteLine($"{order.Key}: {order.Value} time/s");
        }
    }
}