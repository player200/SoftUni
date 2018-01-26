using System;
using System.Linq;
class Program
{
    static void Main()
    {
        int[] stones = Console.ReadLine()
            .Split(new[] { ' ',',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        Lake lake = new Lake(stones);
        Console.WriteLine(string.Join(", ",lake));
    }
}