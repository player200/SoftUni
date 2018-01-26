using System;
public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    public Player(string name,int endurance,int sprint,int dribble,int passing,int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }
    public int Stats { get { return AvaragePlayerStats(); } }
    private int Shooting
    {
        get { return shooting; }
        set
        {
            if (value<0 ||value>100)
            {
                throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");
            }
            shooting = value;
        }
    }
    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");
            }
            passing = value;
        }
    }
    private int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Dribble)} should be between 0 and 100.");
            }
            dribble = value;
        }
    }
    private int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");
            }
            sprint = value;
        }
    }
    private int Endurance
    {
        get { return endurance; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");
            }
            endurance = value;
        }
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
    private int AvaragePlayerStats()
    {
        return (int)Math.Round((this.Dribble + this.Endurance + this.Passing + this.Shooting + this.Sprint) / (double)5);
    }
}