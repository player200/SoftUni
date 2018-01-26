using System.Collections.Generic;
using System.Linq;
public class Family
{
    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }
    public List<Person> FamilyMembers { get; set; }
    
    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }
    public Person GetOldestMember()
    {
        return FamilyMembers.OrderByDescending(f => f.Age).First();
    }
}