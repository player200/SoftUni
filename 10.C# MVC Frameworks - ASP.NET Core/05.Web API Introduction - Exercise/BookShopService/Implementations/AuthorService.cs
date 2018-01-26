namespace BookShop.Service.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookShop.Data;
    using BookShop.Data.Models;
    using BookShop.Service.Models.Author;
    using System.Linq;
    using System.Collections.Generic;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BooksByAuthorIdServiceModel> BooksById(int id)
        {
            return this.db
                .Books
                .Where(b=>b.AuthorId==id)
                .ProjectTo<BooksByAuthorIdServiceModel>()
                .ToList();
        }

        public int Create(string firstName,string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName=lastName
            };

            this.db.Add(author);
            this.db.SaveChanges();

            return author.Id;
        }

        public AuthorDetailsServiceModel Details(int id)
        {
            return this.db
                .Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefault();
        }

        public bool Exists(int id)
        {
            return this.db
                .Authors
                .Any(a => a.Id == id);
        }
    }
}