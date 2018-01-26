namespace BookShop.Service
{
    using BookShop.Service.Models.Author;
    using System.Collections.Generic;

    public interface IAuthorService
    {
        AuthorDetailsServiceModel Details(int id);

        int Create(string firstName, string lastName);

        IEnumerable<BooksByAuthorIdServiceModel> BooksById(int id);

        bool Exists(int id);
    }
}