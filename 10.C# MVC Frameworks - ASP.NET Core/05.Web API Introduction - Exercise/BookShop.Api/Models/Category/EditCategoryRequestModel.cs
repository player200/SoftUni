namespace BookShop.Api.Models.Category
{
    using BookShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryNameMaxleth)]
        public string Name { get; set; }
    }
}