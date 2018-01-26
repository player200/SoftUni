public class Cat : Felime
{
    public Cat(string name, string type, double weight, string leavingRegion,string breed):
        base(name,type,weight,leavingRegion)
    {
        this.Breed = breed;
    }
    private string Breed { get; set; }
    public override string MakeSound()
    {
        return "Meowwww";
    }
    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.Name}, {this.Breed}, {this.Weight}, {this.LeavingRegion}, {this.FoodEaten}]";
    }
}