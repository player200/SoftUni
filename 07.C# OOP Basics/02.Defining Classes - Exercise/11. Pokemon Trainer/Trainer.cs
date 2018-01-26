using System.Collections.Generic;
public class Trainer
{
    public Trainer(string name,int badges,List<Pokemon>pokemons)
    {
        this.Name = name;
        this.Badges = badges;
        this.Pokemons =new List<Pokemon>(pokemons);
    }
    public string Name { get; set; }
    public int Badges { get; set; }
    public List<Pokemon> Pokemons { get; set; }
}
