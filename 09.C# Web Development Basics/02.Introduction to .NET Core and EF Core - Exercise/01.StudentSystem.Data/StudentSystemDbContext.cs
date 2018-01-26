namespace _01.StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    public class StudentSystemDbContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourse { get; set; }

        public DbSet<Homework> Homework { get; set; }

        public DbSet<Resources> Resources { get; set; }

        public DbSet<License> License { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentSystemDb;Integrated Security=True;");

            base.OnConfiguring(builder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<Students>()
                .HasMany(s => s.Coureses)
                .WithOne(sc => sc.Students)
                .HasForeignKey(sc => sc.StudentId);

            builder
                .Entity<Courses>()
                .HasMany(c => c.Students)
                .WithOne(sc => sc.Coureses)
                .HasForeignKey(sc => sc.CourseId);

            builder
                .Entity<Courses>()
                .HasMany(c=>c.Resources)
                .WithOne(r=>r.Courses)
                .HasForeignKey(r=>r.CoureseId);

            builder
                .Entity<Courses>()
                .HasMany(c=>c.Homeworks)
                .WithOne(h=>h.Courses)
                .HasForeignKey(h=>h.CoureseId);

            builder
                .Entity<Students>()
                .HasMany(s => s.Homeworks)
                .WithOne(h=>h.Students)
                .HasForeignKey(h=>h.StudentId);

            builder
                .Entity<Resources>()
                .HasMany(r => r.Licenses)
                .WithOne(l => l.Resource)
                .HasForeignKey(l => l.ResourceId);

            base.OnModelCreating(builder);
        }
    }
}