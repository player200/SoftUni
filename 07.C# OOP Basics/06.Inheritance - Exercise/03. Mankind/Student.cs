using System;
using System.Linq;
using System.Text;
public class Student : Human
{
    private string facoltyNumber;
    public Student(string firstName,string lastName, string facoltyNumber):base(firstName, lastName)
    {
        this.FacoltyNumber = facoltyNumber;
    }
    public string FacoltyNumber
    {
        get { return facoltyNumber; }
        set
        {
            if (value.Length<5 || value.Length>10 || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facoltyNumber = value;
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToString())
            .AppendLine($"Faculty number: {this.FacoltyNumber}");
        return sb.ToString();
    }
}