using System;
using System.Globalization;
namespace _01.Students_Results
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            string inputString = string.Empty;
            Console.WriteLine("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average");
            for (int i = 0; i < number; i++)
            {
                inputString = Console.ReadLine();

                string[] splitInput = inputString
                    .Split(new char[] { ',', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = splitInput[0];
                double firstResult = double.Parse(splitInput[1], CultureInfo.InvariantCulture);
                double secondResult = double.Parse(splitInput[2], CultureInfo.InvariantCulture);
                double thirdResult = double.Parse(splitInput[3], CultureInfo.InvariantCulture);
                double avarage = (firstResult+secondResult+thirdResult)/3;

                Console.WriteLine("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",name,firstResult,secondResult,thirdResult,avarage);
            }
        }
    }
}