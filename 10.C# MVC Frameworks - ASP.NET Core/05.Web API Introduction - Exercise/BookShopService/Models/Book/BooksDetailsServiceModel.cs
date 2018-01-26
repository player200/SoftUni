namespace BookShop.Service.Models.Book
{
    using BookShop.Common.Mapping;
    using BookShop.Service.Models.Author;
    using BookShop.Data.Models;
    using AutoMapper;
    using System.Linq;

    public class BooksDetailsServiceModel : BooksByAuthorIdServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public string Author { get; set; }

        public override void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Book, BooksDetailsServiceModel>()
                .ForMember(b => b.Categories, cfg => cfg
                        .MapFrom(b => b.Categories.Select(c => c.Category.Name)))
                .ForMember(b => b.Author, cfg => cfg.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName));
        }
    }
}