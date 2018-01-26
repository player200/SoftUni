public class Person
{
    public string name;
    public int age;
    public Person()
    {
        this.Name = name;
        this.Age = age;
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
}