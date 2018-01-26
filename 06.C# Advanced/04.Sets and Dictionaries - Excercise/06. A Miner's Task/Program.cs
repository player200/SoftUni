using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            int number ;
            var resoursec = new Dictionary<string,int>();
            while ((input = Console.ReadLine())!= "stop")
            {
                number = int.Parse(Console.ReadLine());
                if (resoursec.ContainsKey(input))
                {
                    resoursec[input] += number;
                }
                else
                {
                    resoursec.Add(input, number);
                }
            }
            foreach (var item in resoursec)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}