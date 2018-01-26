using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var ipCollector = new SortedDictionary<string,Dictionary<string,int>>();

            while (input!= "end")
            {
                var splited = input.Split(' ');
                var ip = splited[0].Replace("IP=","");
                var user = splited[2].Replace("user=", "");

                if (ipCollector.ContainsKey(user))
                {
                    if (ipCollector[user].ContainsKey(ip))
                    {
                        ipCollector[user][ip] += 1;
                    }
                    else
                    {
                        ipCollector[user][ip] = 1;
                    }
                }
                else
                {
                    ipCollector[user] = new Dictionary<string, int>() {{ ip, 1 }};
                }

                input = Console.ReadLine();
            }
            PrintUsersAndIp(ipCollector);
        }
        private static void PrintUsersAndIp(SortedDictionary<string, Dictionary<string, int>> ipCollector)
        {
            foreach (var user in ipCollector)
            {
                Console.WriteLine($"{user.Key}: ");
                Console.WriteLine("{0}.",string.Join(", ",user.Value.Select(a=>$"{a.Key} => {a.Value}")));
            }
        }
    }
}