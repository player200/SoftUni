namespace _03.RequestParser
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> collector = new Dictionary<string, List<string>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine
                    .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string path = $"/{tokens[0]}";
                string method = tokens[1];

                if (!collector.ContainsKey(path))
                {
                    collector[path] = new List<string>();
                }
                collector[path].Add(method);
            }
            string command = Console.ReadLine();
            string[] commandTokens = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string neededMethod = commandTokens[0];
            string neededPath = commandTokens[1];
            string protocol = commandTokens[2];

            int resposNumber = 404;
            string responsText = "Not Found";

            if (collector.ContainsKey(neededPath) && collector[neededPath].Contains(neededMethod.ToLower()))
            {
                resposNumber = 200;
                responsText = "OK";
            }
            Console.WriteLine($"{protocol} {resposNumber} {responsText}");
            Console.WriteLine($"Content-Length: {responsText.Length}");
            Console.WriteLine($"Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine($"{responsText}");
        }
    }
}