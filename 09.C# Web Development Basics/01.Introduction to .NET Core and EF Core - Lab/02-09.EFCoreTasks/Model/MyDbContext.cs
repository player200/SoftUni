namespace _02_09.EFCoreTasks.Model
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreTasksDb;Integrated Security=true;");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Employee>()
                .HasOne(emp => emp.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(emp => emp.DepartmentId);

            builder
                .Entity<Employee>()
                .HasOne(emp => emp.Manager)
                .WithMany(m => m.Employees)
                .HasForeignKey(emp => emp.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            builder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}