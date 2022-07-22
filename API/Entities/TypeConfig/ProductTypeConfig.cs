using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Entities
{
  public class ProductTypeConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Products");
      builder.Property(p => p.Name).HasColumnType("varchar(120)");
      builder.Property(p => p.Description).HasColumnType("varchar(300)");
      builder.Property(p => p.Brand).HasColumnType("varchar(100)");
      builder.Property(p => p.PictureUrl).HasColumnType("varchar(200)");
      builder.Property(p => p.Price).HasColumnType("integer");
      builder.Property(p => p.QuantityInStock).HasColumnType("integer");
      builder.Property(p => p.Type).HasColumnType("varchar(20)");

    }
  }
}