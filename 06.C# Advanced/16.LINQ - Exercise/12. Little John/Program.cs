using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _12.Little_John
{
    class Program
    {
        private const string smallArrow = ">----->";
        private const string mediumArrow = ">>----->";
        private const string bigArrow = ">>>----->>";

        private static void Main()
        {
            List<string> arrows = new List<string>();
            string pattern = @"\>+\-{5}\>+";
            Regex rgx = new Regex(pattern);

            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                var matches = rgx.Matches(input);

                foreach (Match match in matches)
                {
                    arrows.Add(match.Value);
                }
            }
            int smallArrows = 0;
            int mediumArrows = 0;
            int bigArrows = 0;

            foreach (var ar in arrows)
            {
                if (ar.Contains(bigArrow))
                {
                    bigArrows++;
                }
                else if (ar.Contains(mediumArrow))
                {
                    mediumArrows++;
                }
                else if (ar.Contains(smallArrow))
                {
                    smallArrows++;
                }
            }

            int concArrowValues = int.Parse(smallArrows.ToString() + mediumArrows.ToString() + bigArrows.ToString());

            string bin = Convert.ToString(concArrowValues, 2);
            var binReversed = bin.ToCharArray();
            Array.Reverse(binReversed);
            string resBin = bin + (new string(binReversed));

            int result = Convert.ToInt32(resBin, 2);

            Console.WriteLine(result);
        }
    }
}