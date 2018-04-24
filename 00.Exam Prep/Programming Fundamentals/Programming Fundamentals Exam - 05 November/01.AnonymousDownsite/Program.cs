namespace _01.AnonymousDownsite
{
    using System;
    using System.Globalization;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int numberOfWebSites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLost = 0m;
            string[] webSites = new string[numberOfWebSites];

            for (int i = 0; i < numberOfWebSites; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();
                webSites[i] = tokens[0];

                decimal currentLost = decimal.Parse(tokens[1]) * decimal.Parse(tokens[2], CultureInfo.InvariantCulture);
                totalLost += currentLost;
            }

            Console.WriteLine(string.Join(Environment.NewLine, webSites));
            Console.WriteLine($"Total Loss: {totalLost:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(new BigInteger(securityKey), numberOfWebSites)}");
        }
    }
}