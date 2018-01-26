public class Robots:ISociety
{
    public Robots(string model, string id)
    {
        this.Id = id;
        this.Model = model;
    }
    public string Id { get; }
    public string Model { get; }
}