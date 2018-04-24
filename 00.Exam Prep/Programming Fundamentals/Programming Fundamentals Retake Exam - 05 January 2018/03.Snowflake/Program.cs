namespace _03.Snowflake
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var patternSurface = "^[^a-zA-Z0-9]+$";
            var surfaceRegex = new Regex(patternSurface);
            var patternMantle = "^[0-9_]+$";
            var mantleRegex = new Regex(patternMantle);
            var patternTotal = "^[^a-zA-Z0-9]+[0-9_]+([a-zA-Z]+)[0-9_]+[^a-zA-Z0-9]+$";
            var totalRegex = new Regex(patternTotal);

            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            string thirdInput = Console.ReadLine();
            string fourthInput = Console.ReadLine();
            string fifthInput = Console.ReadLine();

            if (!surfaceRegex.IsMatch(firstInput)
                || !mantleRegex.IsMatch(secondInput)
                || !totalRegex.IsMatch(thirdInput)
                || !mantleRegex.IsMatch(fourthInput)
                || !surfaceRegex.IsMatch(fifthInput))
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                Console.WriteLine("Valid");
                foreach (Match match in totalRegex.Matches(thirdInput))
                {
                    Console.WriteLine($"{match.Groups[1].Length}");
                }
            }
        }
    }
}