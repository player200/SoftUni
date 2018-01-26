namespace _05_07.ShopHierarchy.Model
{
    using Microsoft.EntityFrameworkCore;

    public class ShopingDbContext: DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Salesman> Salesman { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemOrders> ItemOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopingDb;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Customer>()
                .HasOne(c=>c.Salesman)
                .WithMany(s=>s.Customers)
                .HasForeignKey(c=>c.SalesmentId);

            builder
                .Entity<Order>()
                .HasOne(o=>o.Customer)
                .WithMany(c=>c.Orders)
                .HasForeignKey(o=>o.CustomerId);

            builder
                .Entity<Review>()
                .HasOne(r=>r.Customer)
                .WithMany(c=>c.Reviews)
                .HasForeignKey(r=>r.CustomerId);

            builder
                .Entity<ItemOrders>()
                .HasKey(io=>new {io.ItemId,io.OrderId });

            builder
                .Entity<Item>()
                .HasMany(i => i.Orders)
                .WithOne(io => io.Item)
                .HasForeignKey(io => io.ItemId);

            builder
                .Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(io => io.Order)
                .HasForeignKey(io => io.OrderId);

            builder
                .Entity<Item>()
                .HasMany(i=>i.Reviews)
                .WithOne(r=>r.Item)
                .HasForeignKey(r=>r.ItemId);
        }
    }
}