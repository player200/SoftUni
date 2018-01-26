using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string secondName = Console.ReadLine();

        List<Card> deck = new List<Card>();
        List<Card> firstPlayer = new List<Card>();
        List<Card> secondPlayer = new List<Card>();
        foreach (var suit in Enum.GetNames(typeof(Suits)))
        {
            foreach (var rank in Enum.GetNames(typeof(Ranks)))
            {
                Card card = new Card(suit, rank);
                deck.Add(card);
            }
        }
        while (firstPlayer.Count < 5 || secondPlayer.Count < 5)
        {
            try
            {
                string[] inpuCards = Console.ReadLine()
                   .Split();
                Card card = new Card(inpuCards[2], inpuCards[0]);
                if (deck.Contains(card))
                {
                    deck.Remove(card);
                    if (firstPlayer.Count < 5)
                    {
                        firstPlayer.Add(card);
                    }
                    else
                    {
                        secondPlayer.Add(card);
                    }
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No such card exists.");
            }
        }
        if (firstPlayer.Max(x => x.CardPower()) > secondPlayer.Max(y => y.CardPower()))
        {
            int maxCard = firstPlayer.Max(x => x.CardPower());
            Card card = firstPlayer.First(x => x.CardPower() == maxCard);
            Console.WriteLine($"{firstName} wins with {card.Rank} of {card.Suit}.");
        }
        else
        {
            int maxCard = secondPlayer.Max(x => x.CardPower());
            Card card = secondPlayer.First(x => x.CardPower() == maxCard);
            Console.WriteLine($"{secondName} wins with {card.Rank} of {card.Suit}.");
        }
    }
}