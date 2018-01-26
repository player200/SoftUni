using System;
using System.Linq;
using System.Text;
namespace _08.Multiply_big_number
{
    class Program
    {
        static void Main()
        {
            string digitOne = Console.ReadLine();
            string digitTwo = Console.ReadLine();
            if (digitTwo == "0" || digitOne == "0")
            {
                Console.WriteLine(0);
                return;
            }
            StringBuilder answer = new StringBuilder();
            int reminder = 0;
            for (int i = 0; i < digitOne.Length; i++)
            {
                int first = int.Parse(digitOne[digitOne.Length - 1 - i].ToString());

                int answ = first * int.Parse(digitTwo) + reminder;

                if (answ >= 10)
                {
                    answer.Append(answ % 10);
                    reminder = answ / 10;
                }
                else
                {
                    answer.Append(answ);
                    reminder = 0;
                }
            }
            if (reminder > 0)
            {
                answer.Append(reminder);
            }

            Console.WriteLine(string.Join("", answer.ToString().Reverse().ToArray()).TrimStart('0'));
        }
    }
}