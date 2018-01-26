public class Citizens:ISociety,IBirthable,IPerson
{
    public Citizens(string name, int age,string id,string birthDay)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.BirthDay = birthDay;
        this.Food = 0;
    }
    public string BirthDay { get; }
    public string Id { get; }
    public string Name { get; }
    public int Age { get; }
    public int Food { get; private set; }
    public void BuyFood()
    {
        this.Food += 10;
    }
}