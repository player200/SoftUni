using System;
class Program
{
    static void Main()
    {
        Scale<int> scale = new Scale<int>(4,4);
        Console.WriteLine(scale.GetHavier());
    }
}