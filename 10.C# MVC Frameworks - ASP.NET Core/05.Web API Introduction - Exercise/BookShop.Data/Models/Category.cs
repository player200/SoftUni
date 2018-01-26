namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryNameMaxleth)]
        public string Name { get; set; }

        public List<CategoryBook> Books { get; set; } = new List<CategoryBook>();
    }
}