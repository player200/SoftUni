namespace CarDealer.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PartsAllModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public string SupplierName { get; set; }
    }
}