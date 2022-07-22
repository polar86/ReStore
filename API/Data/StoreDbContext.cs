using API.Entities;
using API.Entities.TypeConfig;

using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class StoreDbContext : DbContext
  {
    public StoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ProductTypeConfig());
      modelBuilder.ApplyConfiguration(new BasketItemTypeConfig());
      modelBuilder.ApplyConfiguration(new BasketTypeConfig());
    }
  }
}