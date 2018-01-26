using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
class Program
{
    static void Main()
    {
        Dictionary<string,Rectangle> rectangles = new Dictionary<string, Rectangle>();
        int[] numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        for (int i = 0; i < numbers[0]; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string id = tokens[0];
            double width = double.Parse(tokens[1],CultureInfo.InvariantCulture);
            double height = double.Parse(tokens[2], CultureInfo.InvariantCulture);
            double x = double.Parse(tokens[3], CultureInfo.InvariantCulture);
            double y = double.Parse(tokens[4], CultureInfo.InvariantCulture);

            var rectangle = new Rectangle(id, width, height, x, y);
            rectangles[id] = rectangle;
        }
        for (int i = 0; i < numbers[1]; i++)
        {
            string[] names = Console.ReadLine()
                .Split();
            var result = rectangles[names[0]].InteresectsWith(rectangles[names[1]]);
            Console.WriteLine(result.ToString().ToLower());
        }
    }
}