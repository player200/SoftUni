public abstract class Food
{
    protected Food(int happinesPoints)
    {
        this.HappinesPoints = happinesPoints;
    }
    public int HappinesPoints { get; set; }

    public int GetPoints()
    {
        return this.HappinesPoints;
    }
}