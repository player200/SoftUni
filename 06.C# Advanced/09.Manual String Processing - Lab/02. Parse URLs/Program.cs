using System;
namespace _02.Parse_URLs
{
    class Program
    {
        static void Main()
        {
            string[] inputUrl = Console.ReadLine()
                .Split(new[] { "://" },StringSplitOptions.RemoveEmptyEntries);

            if (inputUrl.Length != 2 || inputUrl[1].IndexOf("/")<0)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                int surverIndex = inputUrl[1].IndexOf("/");

                string protocol = inputUrl[0];
                string server = inputUrl[1].Substring(0, surverIndex);
                string resours = inputUrl[1].Substring(surverIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resours}");
            }
        }
    }
}