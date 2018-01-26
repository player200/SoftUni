namespace News.Service
{
    using News.Service.Models;
    using System;
    using System.Collections.Generic;

    public interface INewsService
    {
        IEnumerable<NewsListingServiceModel> All();

        int Create(
            string title,
            string content,
            DateTime publishDate);

        NewsListingServiceModel ById(int id);

        bool Exists(int id);

        int Edit(
            int id,
            string title,
            string context,
            DateTime publishDate);

        int Delete(int id);
    }
}