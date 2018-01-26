public class Citizens:ISociety,IBirthable
{
    public Citizens(string name, int age,string id,string birthDay)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.BirthDay = birthDay;
    }
    public string BirthDay { get; }
    public string Id { get; }
    public string Name { get; }
    public int Age { get; }
}