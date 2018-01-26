public abstract class Mammal : Animal
{
    public Mammal(string name,string type,double weight, string leavingRegion):
        base(name,type,weight)
    {
        this.LeavingRegion = leavingRegion;
    }
    protected string LeavingRegion { get; set; }
    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.Name}, {this.Weight}, {this.LeavingRegion}, {this.FoodEaten}]";
    }
}