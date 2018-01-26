namespace LearningSystem.Service.Blog
{
    using LearningSystem.Service.Blog.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogArticleService
    {
        Task Create(
            string title,
            string content, 
            DateTime publishDate,
            string author);

        Task<IEnumerable<BlogArticleListingServiceModel>> AllAsync();

        Task<IEnumerable<BlogArticleListingServiceModel>> FindAsync(string searchText);
    }
}