using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            string name = string.Empty;
            string email = string.Empty;
            var user = new Dictionary<string,string>();
            while ((name=Console.ReadLine())!="stop")
            {
                email = Console.ReadLine();
                user.Add(name,email);
                if (email.Contains(".us")|| email.Contains(".uk"))
                {
                    user.Remove(name);
                }
            }
            foreach (var item in user)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}