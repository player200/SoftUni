using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace _10.Group_by_Group
{
    class Program
    {
        static void Main()
        {
            List<Person> students = new List<Person>();
            string text = Console.ReadLine();
            while (text != "END")
            {
                var tokens = text.Split();
                students.Add(new Person(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
                text = Console.ReadLine();
            }
            var group=  students.GroupBy(s => s.Group)
                .OrderBy(s => s.Key);
            foreach (var student in group)
            {
                Console.Write(student.Key+" - ");
                var builder = new StringBuilder();
                foreach (var name in student)
                {
                    builder.Append(name.Name).Append(", ");
                }
                builder.Length -= 2;
                Console.WriteLine(builder);
            }
        }
    }
    public class Person
    {
        public Person(string name,int group)
        {
            this.Name = name;
            this.Group = group;
        }
        public string Name { get; set; }

        public int Group { get; set; }
    }
}