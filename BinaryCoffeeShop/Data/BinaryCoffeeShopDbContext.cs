using BinaryCoffeeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BinaryCoffeeShop.Data;

public class BinaryCoffeeShopDbContext : DbContext
{
    public BinaryCoffeeShopDbContext(DbContextOptions<BinaryCoffeeShopDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Direction> Directions { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(user => user.Orders)
            .WithOne(order => order.User)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasMany(product => product.ProductDetails)
            .WithOne(productDetails => productDetails.Product)
            .HasForeignKey(productDetails => productDetails.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasMany(order => order.ProductDetails)
            .WithOne(productDetail => productDetail.Order)
            .HasForeignKey(productDetails => productDetails.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>().Ignore(order => order.Direction);

        modelBuilder.Entity<Category>()
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
