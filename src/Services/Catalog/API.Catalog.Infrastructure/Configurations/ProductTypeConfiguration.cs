using API.Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Catalog.Infrastructure.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable(name: "ProductTypes");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_ProductTypes");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(250)");
        }
    }
}
