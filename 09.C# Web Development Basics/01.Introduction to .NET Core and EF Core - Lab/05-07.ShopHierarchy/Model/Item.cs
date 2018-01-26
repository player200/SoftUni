namespace _05_07.ShopHierarchy.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<ItemOrders> Orders { get; set; } = new List<ItemOrders>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}