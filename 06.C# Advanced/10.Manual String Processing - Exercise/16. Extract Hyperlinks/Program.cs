using System;
using System.Text.RegularExpressions;
using System.Text;
namespace _16.Extract_Hyperlinks
{
    class Program
    {
        static void Main()
        {
            StringBuilder oneLineText = new StringBuilder();
            string line = Console.ReadLine();
            if (line == "END")
            {
                return;
            }
            else
            {
                while (line != "END")
                {
                    oneLineText.Append(line);
                    line = Console.ReadLine();
                }
            }

            string regexPattern = "<a[^>]*?href\\s*=\\s*(?:(?:'([^>]+?)')|(?:\"([^>]+?)\")|([^>]+?\\s+))(?:(?:\\s*>)|(?:[^>]*?>)).*?<\\/a>";

            MatchCollection matches = Regex.Matches(oneLineText.ToString(), regexPattern);
            foreach (Match match in matches)
            {
                if (!match.Groups[1].ToString().Equals(""))
                {
                    Console.WriteLine(match.Groups[1]);
                }
                else if (!match.Groups[2].ToString().Equals(""))
                {
                    Console.WriteLine(match.Groups[2]);
                }
                else if (!match.Groups[3].ToString().Equals(""))
                {
                    Console.WriteLine(match.Groups[3]);
                }
            }
        }
    }
}