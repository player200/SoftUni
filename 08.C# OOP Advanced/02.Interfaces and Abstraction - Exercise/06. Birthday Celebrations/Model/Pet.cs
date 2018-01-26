public class Pet:IBirthable
{
    public Pet(string name,string birthDay)
    {
        this.Name = name;
        this.BirthDay = birthDay;
    }
    public string BirthDay { get; }
    public string Name { get; }
}