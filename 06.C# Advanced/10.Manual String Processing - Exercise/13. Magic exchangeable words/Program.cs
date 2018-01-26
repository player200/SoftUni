using System;
using System.Linq;
namespace _13.Magic_exchangeable_words
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words[0].ToCharArray().Distinct().Count() != words[1].ToCharArray().Distinct().Count())
            {
                Console.WriteLine("false");
                return;
            }
            else
            {
                Console.WriteLine("true");
            }
        }
    }
}