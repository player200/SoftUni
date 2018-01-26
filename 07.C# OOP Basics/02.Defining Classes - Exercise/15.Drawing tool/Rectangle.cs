using System;
public class Rectangle : Square
{
    public Rectangle(int x, int y) : base(x)
    {
        this.Y = y;
    }
    public int Y { get; set; }
    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', this.Y)}|");
        for (int i = 0; i < this.X - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.Y)}|");
        }
        if (X > 1)
        {
            Console.WriteLine($"|{new string('-', this.Y)}|");
        }
    }
}