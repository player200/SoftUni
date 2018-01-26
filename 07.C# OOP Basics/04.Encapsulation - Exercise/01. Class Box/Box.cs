public class Box
{
    private double lenght;
    private double width;
    private double height;
    public Box(double lenght,double width,double height)
    {
        this.lenght = lenght;
        this.width = width;
        this.height = height;
    }
    public double Lenght
    {
        get { return this.lenght; }
    }
    public double Width
    {
        get { return this.width; }
    }
    public double Height
    {
        get { return this.height; }
    }
    public double SurfaceArea()
    {
        return 2*this.lenght*this.width+2*this.lenght*this.height+2*this.width*this.height;
    }
    public double LateralSurfaceArea()
    {
        return 2 * this.lenght * this.height + 2 * this.width * this.height;
    }
    public double Volume()
    {
        return this.lenght*this.width*this.height;
    }
    public override string ToString()
    {
        return $"Surface Area - {SurfaceArea():f2}\nLateral Surface Area - {LateralSurfaceArea():f2}\nVolume - {Volume():f2}";
    }
}
