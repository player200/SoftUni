using System;
public class Cat : Animal
{
    public Cat(string name,string favoriteFood)
    {
        this.Name = name;
        this.FavouriteFood = favoriteFood;
    }
    public override string ExplainMyself()
    {
        return base.ExplainMyself()+ Environment.NewLine+ "MEEOW";
    }
}