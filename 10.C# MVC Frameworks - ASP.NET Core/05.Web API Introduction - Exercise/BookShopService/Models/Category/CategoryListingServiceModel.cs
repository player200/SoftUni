namespace BookShop.Service.Models.Category
{
    using BookShop.Common.Mapping;
    using BookShop.Data.Models;

    public class CategoryListingServiceModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}