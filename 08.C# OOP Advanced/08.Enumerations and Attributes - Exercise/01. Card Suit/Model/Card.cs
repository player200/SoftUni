using System;
public class Card : IComparable<Card>
{
    public Card(string suit, string rank)
    {
        this.Suit = (Suits)Enum.Parse(typeof(Suits), suit);
        this.Rank = (Ranks)Enum.Parse(typeof(Ranks), rank);
    }
    public Suits Suit { get; }
    public Ranks Rank { get; }
    public int CardPower()
    {
        return (int)this.Suit + (int)this.Rank;
    }
    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var rankComperison = this.Rank.CompareTo(other.Rank);
        if (rankComperison != 0)
        {
            return rankComperison;
        }
        return this.Suit.CompareTo(other.Suit);
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        Card card = obj as Card;
        return this.CardPower().Equals(card.CardPower());
    }
    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.CardPower()}";
    }

}