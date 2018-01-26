public class Siamese:Cat
{
    public Siamese(string name, int earSize)
    {
        this.Name = name;
        this.EarSize = earSize;
    }
    public int EarSize { get; set; }
    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}
