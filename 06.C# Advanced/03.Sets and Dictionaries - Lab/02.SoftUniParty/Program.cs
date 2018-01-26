using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var partyList = new SortedSet<string>();
            while (input!="PARTY")
            {
                partyList.Add(input);
                input = Console.ReadLine();
            }
            while (input!="END")
            {
                partyList.Remove(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(partyList.Count);
            foreach (var member in partyList)
            {
                Console.WriteLine(member);
            }
        }
    }
}