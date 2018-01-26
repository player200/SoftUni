namespace _01.StudentSystem.Data
{
    using _01.StudentSystem.Data.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resources
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ResourceType Type { get; set; }

        [Required]
        public string Url { get; set; }

        public int CoureseId { get; set; }

        public Courses Courses { get; set; }

        public List<License> Licenses { get; set; } = new List<License>();
    }
}