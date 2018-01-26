using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace _09.Query_Mess
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                Dictionary<string, List<string>> collector = new Dictionary<string, List<string>>();
                inputLine = Regex.Replace(inputLine, @"(\++|\s+|(%20)+)", " ");
                inputLine = Regex.Replace(inputLine, @"\s+", " ");
                inputLine = Regex.Replace(inputLine, @".*\?", "");
                string[] matches = inputLine
                    .Split('&');
                foreach(var match in matches)
                {
                    string[] keyAndValue = match
                        .Split('=')
                        .Select(w => w.Trim()).ToArray();

                    if (collector.ContainsKey(keyAndValue[0]))
                    {
                        collector[keyAndValue[0]].Add(keyAndValue[1]);
                    }
                    else
                    {
                        collector.Add(keyAndValue[0], new List<string>() { keyAndValue[1] });
                    }
                }

                foreach (var pair in collector)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                }
                Console.WriteLine();
                inputLine = Console.ReadLine();
            }
        }
    }
}
