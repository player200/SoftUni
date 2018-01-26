namespace _01.StudentSystem.Data
{
    using _01.StudentSystem.Data.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public ContentType Type { get; set; }

        public DateTime SubmitionDate { get; set; }

        public int CoureseId { get; set; }

        public Courses Courses { get; set; }

        public int StudentId { get; set; }

        public Students Students { get; set; }
    }
}