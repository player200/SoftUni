using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var uniqueUsers = new HashSet<string>();
            while (number!=0)
            {
                string name = Console.ReadLine();
                uniqueUsers.Add(name);
                number--;
            }
            foreach (var user in uniqueUsers)
            {
                Console.WriteLine(user);
            }
        }
    }
}