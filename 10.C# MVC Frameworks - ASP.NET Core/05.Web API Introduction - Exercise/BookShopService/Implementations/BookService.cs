namespace BookShop.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Service.Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BookListingServiceModel> BooksBySearch(string text)
        {
            return this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(text.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookListingServiceModel>()
                .ToList();
        }

        public int Create(
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId,
            string categories)
        {
            var category = categories
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var categoryId = this.db
                .Categories
                .Where(c => category.Contains(c.Name))
                .Select(c => c.Id)
                .ToList();

            var book = new Book
            {
                Title = title,
                Descrtioption = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };

            categoryId.ForEach(c => book.Categories.Add(new CategoryBook
            {
                CategoryId = c
            }));

            this.db.Add(book);
            this.db.SaveChanges();

            return book.Id;
        }

        public int Delete(int id)
        {
            var book = this.db
                .Books
                .Where(b => b.Id == id)
                .FirstOrDefault();

            this.db.Books.Remove(book);
            this.db.SaveChanges();

            return book.Id;
        }

        public BooksDetailsServiceModel Details(int id)
        {
            return this.db
                .Books
                .Where(b => b.Id == id)
                .ProjectTo<BooksDetailsServiceModel>()
                .FirstOrDefault();
        }

        public int Edit(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition,
            int? ageRestriction,
            DateTime releaseDate,
            int authorId)
        {
            var book = this.db
                .Books
                .Find(id);

            book.Title = title;
            book.Descrtioption = description;
            book.Price = price;
            book.Copies = copies;
            book.Edition = edition;
            book.AgeRestriction = ageRestriction;
            book.ReleaseDate = releaseDate;
            book.AuthorId = authorId;

            this.db.SaveChanges();

            return book.Id;
        }

        public bool Exists(int id)
        {
            return this.db
                .Books
                .Any(b => b.Id == id);
        }
    }
}