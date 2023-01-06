using API.Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Catalog.Infrastructure.Configurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable(name: "ProductBrands");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_ProductBrands");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");
        }
    }
}
