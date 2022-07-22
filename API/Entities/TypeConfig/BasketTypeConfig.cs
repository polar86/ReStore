using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Entities.TypeConfig
{
  public class BasketTypeConfig : IEntityTypeConfiguration<Basket>
  {
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
      builder.ToTable("Baskets");
      builder.Property(b => b.BuyerId).HasColumnType("varchar(120)");
      builder.HasMany(b => b.Items).WithOne().HasForeignKey(i => i.Id);
    }
  }
}