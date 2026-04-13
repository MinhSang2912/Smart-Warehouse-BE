using Microsoft.EntityFrameworkCore;
using Smart_Warehouse.Models.Entities;
using Smart_Warehouse.Models.Entities.Order;
using Smart_Warehouse.Models.Entities.Inventories;
using Smart_Warehouse.Models.Entities.Orders;

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
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", IsActive = true, CreatedAt = DateTime.Today},
                new Role { Id = 2, Name = "Manager", IsActive = true, CreatedAt = DateTime.Today},
                new Role { Id = 3, Name = "Staff", IsActive = true, CreatedAt = DateTime.Today}
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", RoleId = 1, IsActive = true, CreatedAt = DateTime.Today },
                new User { Id = 2, Username = "Sang", Password = "Sang123", RoleId = 2, IsActive = true, CreatedAt = DateTime.Today }
            );

        }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Warehouse> Warehouses { get; set; } = null!;
        public DbSet<Import> Imports { get; set; } = null!;
        public DbSet<ImportDetail> ImportDetails { get; set; } = null!;
        public DbSet<Inventory> Inventories { get; set; } = null!;
        public DbSet<InventoryLog> InventoryLogs { get; set; } = null!; 
        public DbSet<Export> Exports { get; set; } = null!;
        public DbSet<ExportDetail> ExportDetails { get; set; } = null!;
    }
}
