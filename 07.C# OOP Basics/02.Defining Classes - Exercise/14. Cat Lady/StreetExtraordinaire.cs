public class StreetExtraordinaire:Cat
{
    public StreetExtraordinaire(string name, int decibelsOfMeows)
    {
        this.Name = name;
        this.DecibelsOfMeows = decibelsOfMeows;
    }
    public int DecibelsOfMeows { get; set; }
    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
    }
}
