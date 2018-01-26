namespace BookShop.Api.Models.Category
{
    using BookShop.Data;
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryRequestModel
    {
        [Required]
        [MaxLength(DataConstants.CategoryNameMaxleth)]
        public string Name { get; set; }
    }
}