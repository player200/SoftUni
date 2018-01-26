using System;
using System.Collections.Generic;
using System.Linq;
public class Team
{
    private string name;
    private List<Player> players;
    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }
    public int Raiting { get { return AvarageTeamStats(); } }
    private List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }
    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"A name should not be empty.");
            }
            name = value;
        }
    }
    private int AvarageTeamStats()
    {
        if (this.players.Any())
        {
            return (int)this.players.Average(p => p.Stats);
        }
        else
        {
            return 0;
        }
    }
    public void AddPlayers(Player player)
    {
        this.players.Add(player);
    }
    public void RemovePlayers(string player)
    {
        if (!this.players.Any(t=>t.Name==player))
        {
            throw new ArgumentException($"Player {player} is not in {this.Name} team.");
        }
        else
        {
            this.players.Remove(this.players.FirstOrDefault(p => p.Name == player));
        }
    }
    public override string ToString()
    {
        return $"{this.name} - {this.Raiting}";
    }
}