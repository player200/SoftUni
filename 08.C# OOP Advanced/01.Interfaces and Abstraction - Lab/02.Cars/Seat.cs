using System.Text;
public class Seat : ICar
{
    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }
    public string Model { get; }
    public string Color { get; }
    public string Start()
    {
        return "Engine start";
    }
    public string Stop()
    {
        return "Breaaak!";
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} Seat {this.Model}")
            .AppendLine(this.Start())
            .Append(this.Stop());
        return sb.ToString();
    }
}