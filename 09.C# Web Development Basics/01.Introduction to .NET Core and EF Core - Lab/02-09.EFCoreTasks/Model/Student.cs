namespace _02_09.EFCoreTasks.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<StudentCourses> Courses { get; set; } = new List<StudentCourses>();
    }
}