using API.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Orders.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Products", b => b.IsTemporal());
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_Products");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder
                .Property(e => e.Price)
                .HasPrecision(18, 2);
        }
    }
}
