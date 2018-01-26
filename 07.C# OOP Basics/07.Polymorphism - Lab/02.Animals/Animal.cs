public class Animal
{
    private string name;
    private string favouriteFood;

    public string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public virtual string ExplainMyself()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
    }
}