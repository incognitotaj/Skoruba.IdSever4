using API.Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Catalog.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(name: "Products");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_Products");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.HasOne(p => p.ProductBrand)
                .WithMany(p => p.Products)
                .IsRequired()
                .HasForeignKey(p => p.ProductBrandId)
                .HasConstraintName("FK_Products_ProductBrand");


            builder.HasOne(p => p.ProductType)
                .WithMany(p => p.Products)
                .IsRequired()
                .HasForeignKey(p => p.ProductTypeId)
                .HasConstraintName("FK_Products_ProductType");
        }
    }
}
