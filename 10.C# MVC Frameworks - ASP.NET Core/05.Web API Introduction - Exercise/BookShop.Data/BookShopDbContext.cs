namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryBook> CategoryBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<CategoryBook>()
                .HasKey(cb => new { cb.CategoryId, cb.BookId });

            builder
                .Entity<Book>()
                .HasMany(b => b.Categories)
                .WithOne(cb => cb.Book)
                .HasForeignKey(cb => cb.BookId);

            builder
                .Entity<Category>()
                .HasMany(b => b.Books)
                .WithOne(cb => cb.Category)
                .HasForeignKey(cb => cb.CategoryId);

            builder
                .Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}