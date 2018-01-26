using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _11.Logs_Aggregator
{
    class Program
    {
        static void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());
            var logAgrigations = new SortedDictionary<string,SortedDictionary<string,int>>();
            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                var tokents = input.Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                var ip = tokents[0];
                var user = tokents[1];
                var duration =int.Parse(tokents[2]);

                if (logAgrigations.ContainsKey(user))
                {
                    if (logAgrigations[user].ContainsKey(ip))
                    {
                        logAgrigations[user][ip] += duration;
                    }
                    else
                    {
                        logAgrigations[user][ip] = duration;
                    }
                }
                else
                {
                    logAgrigations[user] = new SortedDictionary<string, int>() { { ip, duration } };
                }
            }
            foreach (var users in logAgrigations)
            {

                Console.WriteLine($"{users.Key}: {users.Value.Values.Sum()} [{string.Join(", ", users.Value.Keys)}]");
            }
        }
    }
}