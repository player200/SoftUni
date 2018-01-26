public class Citizens:ISociety
{
    public Citizens(string name, int age,string id)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
    }
    public string Id { get; }
    public string Name { get; }
    public int Age { get; }
}