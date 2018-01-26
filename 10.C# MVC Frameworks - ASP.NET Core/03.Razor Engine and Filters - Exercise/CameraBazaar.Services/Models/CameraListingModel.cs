namespace CameraBazaar.Services.Models
{
    using CameraBazaar.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class CameraListingModel
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}