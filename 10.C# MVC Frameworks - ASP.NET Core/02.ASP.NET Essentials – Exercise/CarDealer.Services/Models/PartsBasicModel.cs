namespace CarDealer.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PartsBasicModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}