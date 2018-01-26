using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Hands_of_Cards
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var dictionary = new Dictionary<string,HashSet<string>>();

            while (input!= "JOKER")
            {
                var tokens = input.Split(':');
                var players = tokens[0];
                var cards = tokens[1]
                    .Split(',')
                    .Select(a => a.Trim())
                    .ToArray();
                if (dictionary.ContainsKey(players))
                {
                    dictionary[players].UnionWith(cards);
                }
                else
                {
                    dictionary[players] = new HashSet<string>(cards);
                }

                input = Console.ReadLine();
            }
            PrintPlayers(dictionary);
        }
        private static void PrintPlayers(Dictionary<string, HashSet<string>> dictionary)
        {
            foreach (var diction in dictionary)
            {
                var score = CalculateScore(diction.Value);
                Console.WriteLine($"{diction.Key}: {score}");
            }
        }
        private static int CalculateScore(HashSet<string> dictionValue)
        {
            var totalScore = 0;
            foreach (var value in dictionValue)
            {
                var type = value.Last();
                var number = value.Substring(0,value.Length-1);
                int score;
                var isNumber = int.TryParse(number,out score);

                if (!isNumber)
                {
                    switch (number)
                    {
                        case "J":
                            score = 11;
                            break;
                        case "Q":
                            score = 12;
                            break;
                        case "K":
                            score = 13;
                            break;
                        case "A":
                            score = 14;
                            break;
                    }
                }
                switch (type)
                {
                    case 'S':
                        score *= 4;
                        break;
                    case 'H':
                        score *= 3;
                        break;
                    case 'D':
                        score *= 2;
                        break;
                    case 'C':
                        score *= 1;
                        break;
                }
                totalScore += score;
                
            }
            return totalScore;
        }
    }
}