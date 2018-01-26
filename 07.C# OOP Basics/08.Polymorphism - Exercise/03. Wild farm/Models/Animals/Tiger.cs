using System;
public class Tiger : Felime
{
    public Tiger(string name, string type, double weight,string leavingRegion):
        base(name,type,weight,leavingRegion)
    {
    }
    public override void Eat(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
        }

        base.Eat(food);
    }
    public override string MakeSound()
    {
        return "ROAAR!!!";
    }
}