namespace _02_09.EFCoreTasks.Model
{
    public class StudentCourses
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}