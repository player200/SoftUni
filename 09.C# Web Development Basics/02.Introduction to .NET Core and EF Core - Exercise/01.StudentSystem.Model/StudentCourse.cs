namespace _01.StudentSystem.Data
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public Students Students { get; set; }

        public int CourseId { get; set; }

        public Courses Coureses { get; set; }
    }
}