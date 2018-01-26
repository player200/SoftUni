using System;
using System.Text.RegularExpressions;
using System.Text;
namespace _10.Use_Your_Chains__Buddy
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"<p>(.+?)<\/p>");
            MatchCollection matches = regex.Matches(input);
            var builder = new StringBuilder();
            var removeMultipleSpaces = string.Empty;
            foreach (Match match in matches)
            {
                var pattern = "[^a-z0-9]+";
                var reminder = match.Groups[1].Value;
                var removed = Regex.Replace(reminder,pattern," ");
                
                foreach (var chars in removed)
                {
                    if (chars>='a'&&chars<='m')
                    {
                        builder.Append((char)(chars + 13));
                    }
                    else if (chars>='n'&&chars<='z')
                    {
                        builder.Append((char)(chars - 13));
                    }
                    else
                    {
                        builder.Append(chars);
                    }
                }

                removeMultipleSpaces =builder.ToString().Replace("\\s+"," ");
            }
            Console.WriteLine(removeMultipleSpaces);
        }
    }
}