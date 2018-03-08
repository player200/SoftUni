public class Person
{
    public Person(string name, string email, int age,string town)
    {
        this.Name = name;
        this.Email = email;
        this.Age = age;
        this.Town = town;
    }

    public string Email { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Town { get; set; }
}