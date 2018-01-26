namespace _02_09.EFCoreTasks.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<StudentCourses> Students { get; set; } = new List<StudentCourses>();
    }
}