namespace _01.StudentSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ResourceId { get; set; }

        public Resources Resource { get; set; }
    }
}