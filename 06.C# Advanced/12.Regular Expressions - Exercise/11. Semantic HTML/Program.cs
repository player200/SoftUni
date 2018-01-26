using System;
using System.Text.RegularExpressions;
namespace _11.Semantic_HTML
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            while (inputLine!="END")
            {
                Match openingTag = Regex.Match(inputLine
                    , @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>");
                Match closeTag = Regex.Match(inputLine
                   , @"<\/div>\s*<!--\s*(.*?)\s*-->");

                if (openingTag.Success)
                {
                    inputLine = Regex.Replace(inputLine
                        , @"<(div)([^>]+)(?:id|class)\s*=\s*""(.*?)""(.*?)>"
                        , @"$3 $2 $4")
                        .Trim();
                    inputLine = "<" + Regex.Replace(inputLine,@"\s+"," ")+">";
                }
                else if (closeTag.Success)
                {
                    inputLine = "</" + closeTag.Groups[1] + ">";
                }
                Console.WriteLine(inputLine);
                inputLine = Console.ReadLine();
            }
        }
    }
}