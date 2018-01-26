namespace News.Service.Models
{
    using News.Common.Mapping;
    using News.Data.Models;
    using System;

    public class NewsListingServiceModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}