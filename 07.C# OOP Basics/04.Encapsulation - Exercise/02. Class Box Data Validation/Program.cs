using System;
using System.Linq;
using System.Globalization;
using System.Reflection;
class Program
{
    static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());
        try
        {
            double lenght = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Box box = new Box(lenght, width, height);
            Console.WriteLine(box.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}