namespace _01.PadawanEquipment
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main()
        {
            double money = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int students = int.Parse(Console.ReadLine());
            double priceSebre = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double priceRobe = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double priceBelt = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            int freeBelts = students / 6;
            double sebreMultiplier = students + (Math.Ceiling(students * 0.1));
            int beltsMultiplier = students - freeBelts;

            double result = priceSebre * sebreMultiplier + priceRobe * students + priceBelt * beltsMultiplier;

            if (result > money)
            {
                Console.WriteLine($"Ivan Cho will need {(result-money):f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {result:f2}lv.");
            }
        }
    }
}