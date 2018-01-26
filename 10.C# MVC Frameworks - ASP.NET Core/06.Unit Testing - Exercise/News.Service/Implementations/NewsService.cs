namespace News.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using News.Data;
    using News.Data.Models;
    using News.Service.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class NewsService : INewsService
    {
        private readonly NewsDbContext db;

        public NewsService(NewsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<NewsListingServiceModel> All()
        {
            return this.db
                .News
                .OrderBy(n => n.PublishDate)
                .ProjectTo<NewsListingServiceModel>()
                .ToList();
        }

        public NewsListingServiceModel ById(int id)
        {
            return this.db
                .News
                .Where(n => n.Id == id)
                .ProjectTo<NewsListingServiceModel>()
                .FirstOrDefault();
        }
        
        public int Create(
            string title,
            string content,
            DateTime publishDate)
        {
            var news = new News
            {
                Title=title,
                Content=content,
                PublishDate=publishDate
            };

            this.db.News.Add(news);
            this.db.SaveChanges();

            return news.Id;
        }

        public int Delete(int id)
        {
            this.db.News.Remove(this.db.News.Find(id));
            this.db.SaveChanges();

            return id;
        }

        public int Edit(
            int id,
            string title, 
            string context,
            DateTime publishDate)
        {
            var news = this.db.News.Find(id);

            news.Title = title;
            news.Content = context;
            news.PublishDate = publishDate;

            this.db.SaveChanges();

            return news.Id;
        }

        public bool Exists(int id)
        {
            return this.db
                .News
                .Any(n=>n.Id==id);
        }
    }
}