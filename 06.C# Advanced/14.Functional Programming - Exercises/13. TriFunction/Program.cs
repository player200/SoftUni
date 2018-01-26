using System;
namespace _13.TriFunction
{
    class Program
    {
        static void Main()
        {
            int limit = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ');

            Func<string, int, bool> isLongEnough = (w, n) =>
            {
                var sumOfChars = 0;

                foreach (var c in w)
                {
                    sumOfChars += c;
                }

                if (sumOfChars >= n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            string result = FindMatchingName(isLongEnough, names, limit);

            Console.WriteLine(result);
        }

        private static string FindMatchingName(Func<string, int, bool> isLongEnough, string[] names, int limit)
        {
            string res = string.Empty;

            foreach (var name in names)
            {
                if (isLongEnough(name, limit))
                {
                    res = name;
                    break;
                }
            }

            return res;
        }
    }
}