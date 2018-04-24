namespace _01.Snowballs
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            BigInteger bestSnowball = int.MinValue;
            string output = string.Empty;

            for (int i = 0; i < count; i++)
            {
                double snowballSnow = double.Parse(Console.ReadLine());
                double snowballTime = double.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger calc = (BigInteger)(snowballSnow / snowballTime);

                BigInteger currentVal = BigInteger.Pow(calc, snowballQuality);
                if (bestSnowball < currentVal)
                {
                    bestSnowball = currentVal;
                    output = $"{snowballSnow} : {snowballTime} = {bestSnowball} ({snowballQuality})";
                }
            }

            Console.WriteLine(output);
        }
    }
}