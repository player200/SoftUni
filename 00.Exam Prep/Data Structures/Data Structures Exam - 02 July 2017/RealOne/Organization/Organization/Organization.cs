using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Organization : IOrganization
{
    private List<Person> organization;
    private Bag<string> containsName;

    public Organization()
    {
        this.organization = new List<Person>();
        this.containsName = new Bag<string>();
    }

    public int Count { get { return this.organization.Count; } }

    public bool ContainsByName(string name)
    {
        string result;
        int results = this.containsName.GetRepresentativeItem(name, out result);
        return results == 0 ? false : true;
    }

    public void Add(Person person)
    {
        this.organization.Add(person);
        this.containsName.Add(person.Name);
    }

    public Person GetAtIndex(int index)
    {
        if (this.organization.Count < index - 1)
        {
            throw new IndexOutOfRangeException();
        }

        return this.organization[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        return this.organization
            .Where(x => x.Name == name);
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return this.organization.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        return this.organization
            .Where(x => x.Name.Length >= minLength
            && x.Name.Length <= maxLength);
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!this.organization.Any(x => x.Name.Length == length))
        {
            throw new ArgumentException();
        }
        return this.organization
            .Where(x => x.Name.Length == length);
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.organization;
    }

    public bool Contains(Person person)
    {
        string result;
        int results = this.containsName.GetRepresentativeItem(person.Name, out result);
        return results == 0 ? false : true;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var employee in this.organization)
        {
            yield return employee;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}