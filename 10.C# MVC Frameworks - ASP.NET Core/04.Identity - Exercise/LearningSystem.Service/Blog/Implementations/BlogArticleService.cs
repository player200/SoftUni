namespace LearningSystem.Service.Blog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Service.Blog.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogArticleService : IBlogArticleService
    {
        private readonly LearningSystemDbContext db;

        public BlogArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BlogArticleListingServiceModel>> AllAsync()
        {
            return await this.db
                .Articles
                .ProjectTo<BlogArticleListingServiceModel>()
                .ToListAsync();
        }

        public async Task Create(
            string title,
            string content,
            DateTime publishDate,
            string author)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = publishDate,
                AuthorId = author
            };

            this.db.Add(article);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogArticleListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
                .Articles
                .OrderBy(u => u.Title)
                .Where(u => u.Title.ToLower().Contains(searchText.ToLower()) 
                            || u.Content.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<BlogArticleListingServiceModel>()
                .ToListAsync();
        }
    }
}