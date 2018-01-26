using System;
using System.Reflection;
class Program
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }
        Family family = new Family();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            family.AddMember(new Person(name, age));
        }

        Person oldest = family.GetOldestMember();
        Console.WriteLine($"{oldest.Name} {oldest.Age}");
    }
}