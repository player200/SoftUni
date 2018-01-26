using System;
using System.Collections.Generic;
using System.Linq;
namespace _11.Students_Joined_to_Specialties
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            List<StudentSpecial> specialStudents = new List<StudentSpecial>();
            string input = string.Empty;
            while ((input=Console.ReadLine())!= "Students:")
            {
                var tokens = input.Split();
                specialStudents.Add(new StudentSpecial(tokens[0]+" "+tokens[1],int.Parse(tokens[2])));
            }
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                students.Add(new Student(tokens[1] + " " + tokens[2], int.Parse(tokens[0])));
            }
            specialStudents.Join(students, sp => sp.FacultyNumber, st => st.FacultyNumber, (sp, st) => new
            {
                Name = st.Students,
                FacultyNumber = sp.FacultyNumber,
                Spec = sp.SpecialStudent
            })
            .OrderBy(res=>res.Name)
            .ToList()
            .ForEach(res => Console.WriteLine($"{res.Name} {res.FacultyNumber} {res.Spec}"));
        }
    }
    public class Student
    {
        public Student(string name,int number)
        {
            this.Students = name;
            this.FacultyNumber = number;
        }
        public string  Students { get; set; }
        public int FacultyNumber { get; set; }
    }
    public class StudentSpecial
    {
        public StudentSpecial(string name, int number)
        {
            this.SpecialStudent = name;
            this.FacultyNumber = number;
        }
        public string SpecialStudent { get; set; }
        public int FacultyNumber { get; set; }
    }
}