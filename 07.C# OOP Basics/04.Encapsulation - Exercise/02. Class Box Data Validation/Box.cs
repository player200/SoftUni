using System;
public class Box
{
    private double lenght;
    private double width;
    private double height;
    public Box(double lenght,double width,double height)
    {
        this.Length = lenght;
        this.Width = width;
        this.Height = height;
    }
    private double Length
    {
        set
        {
            if (value<=0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            this.lenght = value;
        }
    }
    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            this.height = value;
        }
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
