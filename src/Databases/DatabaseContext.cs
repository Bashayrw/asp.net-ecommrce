using CodeCrafters_backend_teamwork.src.Entities;
using CodeCrafters_backend_teamwork.src.Enums;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Databases;
public class DatabaseContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderCheckout> OrderCheckouts { get; set; }
    public DbSet<Category> Category { get; set; }


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
    }
}
