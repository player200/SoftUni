using System;
namespace _12.Character_Multiplier
{
    class Program
    {
        static void Main()
        {
            string[] inputWords =
                Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstWord = inputWords[0];
            string secondWord = inputWords[1];
            long result = 0;

            for (int i = 0; i < Math.Max(firstWord.Length, secondWord.Length); i++)
            {
                int digitOne = 1;
                int digitTwo = 1;

                if (i < firstWord.Length)
                {
                    digitOne = (int)firstWord[i];
                }

                if (i < secondWord.Length)
                {
                    digitTwo = (int)secondWord[i];
                }

                result += digitOne * digitTwo;
            }
            Console.WriteLine(result);
        }
    }
}