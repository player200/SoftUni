using System;
public class Square
{
    public Square(int x)
    {
        this.X = x;
    }
    public int X { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine($"|{new string('-',this.X)}|");
        for (int i = 0; i < this.X-2; i++)
        {
            Console.WriteLine($"|{new string(' ', this.X)}|");
        }
        if (X>1)
        {
            Console.WriteLine($"|{new string('-', this.X)}|");
        }
    }
}
