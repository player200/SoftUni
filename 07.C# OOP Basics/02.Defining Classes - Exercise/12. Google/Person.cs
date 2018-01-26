using System.Collections.Generic;
public class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parents>();
        this.Children = new List<Children>();
    }

    public string Name { get; set; }
    public Company Company { get; set; }
    public ICollection<Pokemon> Pokemons { get; set; }
    public ICollection<Parents> Parents { get; set; }
    public ICollection<Children> Children { get; set; }
    public Car Car { get; set; }
}
