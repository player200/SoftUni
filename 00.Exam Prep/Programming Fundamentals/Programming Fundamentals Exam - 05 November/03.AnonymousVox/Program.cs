namespace _03.AnonymousVox
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var regPattern = new Regex(@"([a-zA-Z]+)([\x00-\x7F]*)(\1)");

            string inputText = Console.ReadLine();
            string[] placeHolders = Console.ReadLine()
                .Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            
            int counter = 0;
            foreach (Match match in regPattern.Matches(inputText))
            {
                if (placeHolders.Length > counter)
                {
                    string newValue = match.Groups[1].Value + placeHolders[counter] + match.Groups[3].Value;
                    inputText = inputText.Replace(match.Value, newValue);
                    counter++;
                }
            }

            Console.WriteLine(inputText);
        }
    }
}