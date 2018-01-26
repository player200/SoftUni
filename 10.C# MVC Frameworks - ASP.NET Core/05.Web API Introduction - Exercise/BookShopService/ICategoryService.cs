namespace BookShop.Service
{
    using BookShop.Service.Models.Category;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryListingServiceModel> All();

        CategoryListingServiceModel Details(int id);

        bool Exists(string name);

        bool ExistsById(int id);

        int Create(string name);

        int Edit(int id, string name);

        int Delete(int id);
    }
}