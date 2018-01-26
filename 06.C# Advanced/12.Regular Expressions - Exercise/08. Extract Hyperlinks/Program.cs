using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
namespace _08.Extract_Hyperlinks
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            while (inputLine!="END")
            {
                builder.Append(inputLine).Append(" ");
                inputLine = Console.ReadLine();
            }
            MatchCollection matches = Regex.Matches(builder.ToString(), @"<a\s+[^>]*?href\s*=(.*?)>.*?<\/\s*a\s*>");
            foreach (Match match in matches)
            {
                string hrefs = match.Groups[1].ToString().Trim();
                if (hrefs[0]=='\"')
                {
                    Console.WriteLine(hrefs
                        .Split(new[] { '"'},StringSplitOptions.RemoveEmptyEntries)
                        .First());
                }
                else if (hrefs[0] == '\'')
                {
                    Console.WriteLine(hrefs
                        .Split(new[] { '\'' }, StringSplitOptions.RemoveEmptyEntries)
                        .First());
                }
                else
                {
                    Console.WriteLine(Regex.Split(hrefs,@"\s+")
                        .First());
                }
            }
        }
    }
}