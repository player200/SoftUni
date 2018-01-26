namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    using LearningSystem.Service.Blog.Models;
    using System.Collections.Generic;

    public class SearchArticlesViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }

        public string SearchText { get; set; }
    }
}