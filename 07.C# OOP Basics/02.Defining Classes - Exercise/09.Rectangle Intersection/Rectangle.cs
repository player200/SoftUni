public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double x;
    private double y;
    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.x = x;
        this.y = y;
    }
    public double Height
    {
        get { return this.height; }
    }
    public double Width
    {
        get { return this.width; }
    }
    public double X
    {
        get { return this.x; }
    }
    public double Y
    {
        get { return this.y; }
    }

    public bool InteresectsWith(Rectangle rectangle)
    {
        if (this.x <= rectangle.x + rectangle.width && this.x + this.width >= rectangle.x && this.y <= rectangle.y + rectangle.height && this.y + this.height >= rectangle.y)
        {
            return true;
        }

        return false;
    }
}
