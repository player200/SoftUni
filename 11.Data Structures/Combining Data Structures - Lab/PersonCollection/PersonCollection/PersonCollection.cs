using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> byEmail =
        new Dictionary<string, Person>();

    private Dictionary<string, SortedDictionary<string, Person>> byDomain =
        new Dictionary<string, SortedDictionary<string, Person>>();

    private Dictionary<string, SortedDictionary<string, Person>> byNameTown =
        new Dictionary<string, SortedDictionary<string, Person>>();

    private OrderedDictionary<int, SortedDictionary<string, Person>> byAge =
         new OrderedDictionary<int, SortedDictionary<string, Person>>();

    private Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>> byTownAge =
         new Dictionary<string, OrderedDictionary<int, SortedDictionary<string, Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        Person personToAdd = new Person(name, email, age, town);

        if (this.byEmail.ContainsKey(email))
        {
            return false;

        }

        this.byEmail[email] = personToAdd;
        this.AddPerson(email, personToAdd);
        this.AddPerson(name, town, email, personToAdd);
        this.AddPerson(age, email, personToAdd);
        this.AddPerson(town, age, email, personToAdd);

        return true;
    }

    public int Count
    {
        get
        {
            return this.byEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        if (!this.byEmail.ContainsKey(email))
        {
            return null;
        }

        return this.byEmail[email];
    }

    public bool DeletePerson(string email)
    {
        Person checkPerson = this.FindPerson(email);

        if (checkPerson == null)
        {
            return false;
        }

        string townName = checkPerson.Town + " " + checkPerson.Name;

        if (!this.byEmail.ContainsKey(email))
        {
            return false;
        }

        string domain = email.Split('@')[1];

        this.byEmail.Remove(email);
        this.byDomain[domain].Remove(email);
        this.byNameTown[townName].Remove(email);
        this.byAge[checkPerson.Age].Remove(email);
        this.byTownAge[checkPerson.Town][checkPerson.Age].Remove(email);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.byDomain.ContainsKey(emailDomain))
        {
            return new List<Person>();
        }

        return this.byDomain[emailDomain].Values;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string townName = town + " " + name;

        if (!this.byNameTown.ContainsKey(townName))
        {
            return new List<Person>();
        }

        return this.byNameTown[townName].Values;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var items = this.byAge.Range(startAge, true, endAge, true);

        foreach (var item in items.Values)
        {
            foreach (var person in item.Values)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (!this.byTownAge.ContainsKey(town))
        {
            return new List<Person>();
        }
        else
        {
            var items = this.byTownAge[town].Range(startAge, true, endAge, true).Values;
            List<Person> result = new List<Person>();
            foreach (var item in items)
            {
                foreach (var ages in item.Values)
                {
                    result.Add(ages);
                }
            }
            return result;
        }
    }

    private void AddPerson(string town, int age, string email, Person personToAdd)
    {
        if (!this.byTownAge.ContainsKey(town))
        {
            this.byTownAge[town] = new OrderedDictionary<int, SortedDictionary<string, Person>>();
        }
        if (!this.byTownAge[town].ContainsKey(age))
        {
            this.byTownAge[town][age] = new SortedDictionary<string, Person>();
        }
        if (!this.byTownAge[town][age].ContainsKey(email))
        {
            this.byTownAge[town][age][email] = personToAdd;
        }
    }

    private void AddPerson(int age, string email, Person personToAdd)
    {
        if (!this.byAge.ContainsKey(age))
        {
            this.byAge[age] = new SortedDictionary<string, Person>();
        }
        if (!this.byAge[age].ContainsKey(email))
        {
            this.byAge[age][email] = personToAdd;
        }
    }

    private void AddPerson(string name, string town, string email, Person personToAdd)
    {
        string townName = town + " " + name;

        if (!this.byNameTown.ContainsKey(townName))
        {
            this.byNameTown[townName] = new SortedDictionary<string, Person>();
        }

        if (!this.byNameTown[townName].ContainsKey(email))
        {
            this.byNameTown[townName][email] = personToAdd;
        }
    }

    private void AddPerson(string email, Person personToAdd)
    {
        string domain = email.Split('@')[1];

        if (!this.byDomain.ContainsKey(domain))
        {
            this.byDomain[domain] = new SortedDictionary<string, Person>();
        }

        if (!this.byDomain[domain].ContainsKey(email))
        {
            this.byDomain[domain][email] = personToAdd;
        }
    }
}