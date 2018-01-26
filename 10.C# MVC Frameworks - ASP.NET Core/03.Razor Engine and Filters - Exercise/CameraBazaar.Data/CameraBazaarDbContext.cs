namespace CameraBazaar.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using CameraBazaar.Data.Models;

    //if program dont build start your database !!!


    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Camera>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cameras)
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}