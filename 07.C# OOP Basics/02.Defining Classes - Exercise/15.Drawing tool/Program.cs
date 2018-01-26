using System;
class Program
{
    static void Main()
    {
        Square squere = null;
        string type = Console.ReadLine();
        switch (type)
        {
            case "Square":
                int x = int.Parse(Console.ReadLine());
                squere=new Square(x);
                break;
            case "Rectangle":
                int y = int.Parse(Console.ReadLine());
                int x1 = int.Parse(Console.ReadLine());
                squere = new Rectangle(x1,y);
                break;
        }
        CorDraw draw = new CorDraw(squere);
        draw.Figure.Draw();
    }
}
