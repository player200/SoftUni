namespace _01.StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Students
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? BirthDay { get; set; }

        public List<StudentCourse> Coureses { get; set; } = new List<StudentCourse>();

        public List<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}