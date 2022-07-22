using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Entities.TypeConfig
{
  public class BasketItemTypeConfig : IEntityTypeConfiguration<BasketItem>
  {
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
      builder.ToTable("BasketItems");
      builder.Property(bi => bi.Quantity).HasColumnType("integer");
      builder.HasOne(bi => bi.Product).WithOne();
      builder.HasOne(bi => bi.Basket).WithOne();
    }
  }
}