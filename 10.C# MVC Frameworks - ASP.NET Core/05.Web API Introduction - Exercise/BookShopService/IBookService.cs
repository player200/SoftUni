namespace BookShop.Service
{
    using BookShop.Service.Models.Book;
    using System;
    using System.Collections.Generic;

    public interface IBookService
    {
        BooksDetailsServiceModel Details(int id);

        IEnumerable<BookListingServiceModel> BooksBySearch(string text);

        int Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId,
            string categories);

        int Edit(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId);

        bool Exists(int id);

        int Delete(int id);
    }
}