namespace BookShop.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Service.Models.Category;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly BookShopDbContext db;

        public CategoryService(BookShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryListingServiceModel> All()
        {
            return this.db
                .Categories
                .ProjectTo<CategoryListingServiceModel>()
                .ToList();
        }

        public int Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Add(category);
            this.db.SaveChanges();

            return category.Id;
        }

        public int Delete(int id)
        {
            var category = this.db
                 .Categories
                 .Where(b => b.Id == id)
                 .FirstOrDefault();

            this.db.Categories.Remove(category);
            this.db.SaveChanges();

            return category.Id;
        }

        public CategoryListingServiceModel Details(int id)
        {
            return this.db
                .Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryListingServiceModel>()
                .FirstOrDefault();
        }

        public int Edit(int id, string name)
        {
            var category = this.db.Categories.Find(id);

            category.Name = name;
            this.db.SaveChanges();

            return category.Id;
        }

        public bool Exists(string name)
        {
            return this.db
                .Categories
                .Any(c => c.Name == name);
        }

        public bool ExistsById(int id)
        {
            return this.db
                .Categories
                .Any(c => c.Id == id);
        }
    }
}