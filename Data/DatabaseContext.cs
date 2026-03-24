using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Models.Entities;

namespace Smart_Warehouse.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships and constraints here if needed
        }
        public DbSet<Catagory> Catagories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
