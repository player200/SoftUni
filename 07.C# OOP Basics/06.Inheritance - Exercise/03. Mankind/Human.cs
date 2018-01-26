using System;
using System.Text;
public class Human
{
    private string firstName;
    private string lastName;
    public Human(string firstName,string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public string LastName
    {
        get { return lastName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            }
            else if (value.Length<4)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}");
        return sb.ToString();
    }
}