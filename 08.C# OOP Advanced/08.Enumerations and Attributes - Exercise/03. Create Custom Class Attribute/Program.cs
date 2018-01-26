using System;
class Program
{
    static void Main()
    {
        CustomAttribute attribute = (CustomAttribute)Attribute.GetCustomAttribute(typeof(Weapon), typeof(CustomAttribute));
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            switch (inputLine)
            {
                case "Author":
                    Console.WriteLine($"Author: {attribute.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attribute.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attribute.Descript}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ",attribute.Reviewer)}");
                    break;
            }
        }
    }
}