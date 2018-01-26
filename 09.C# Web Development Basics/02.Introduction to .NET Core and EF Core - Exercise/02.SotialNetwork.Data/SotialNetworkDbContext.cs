namespace _02.SotialNetwork.Data
{
    using _02.SotialNetwork.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class SotialNetworkDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<FriendShip> FriendShip { get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<Picture> Picture { get; set; }

        //public DbSet<AlbumPicture> AlbumPicture { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SotialNetworkDb;Integrated Security=True;");

            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<FriendShip>()
                .HasKey(fs => new { fs.FromUserId, fs.ToUserId });

            builder
                .Entity<Users>()
                .HasMany(u => u.FromFriends)
                .WithOne(f => f.FromUser)
                .HasForeignKey(f => f.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Users>()
                .HasMany(u => u.ToFriends)
                .WithOne(f => f.ToUser)
                .HasForeignKey(f => f.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AlbumPicture>()
                .HasKey(ap => new { ap.AlbumId, ap.PictureId });

            builder
                .Entity<Picture>()
                .HasMany(p => p.Albums)
                .WithOne(ap => ap.Picture)
                .HasForeignKey(ap => ap.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Album>()
                .HasMany(a => a.Pictures)
                .WithOne(ap => ap.Album)
                .HasForeignKey(ap => ap.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Users>()
                .HasMany(u => u.Albums)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var serviceProvider = this.GetService<IServiceProvider>();
            var items = new Dictionary<object, object>();

            foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
            {
                var entity = entry.Entity;
                var context = new ValidationContext(entity, serviceProvider, items);
                var results = new List<ValidationResult>();

                if (Validator.TryValidateObject(entity, context, results, true) == false)
                {
                    foreach (var result in results)
                    {
                        if (result != ValidationResult.Success)
                        {
                            throw new ValidationException(result.ErrorMessage);
                        }
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}