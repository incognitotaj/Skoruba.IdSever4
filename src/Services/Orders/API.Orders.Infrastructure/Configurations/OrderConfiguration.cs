using API.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Orders.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(name: "Orders", b => b.IsTemporal());
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_Orders");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Customer)
                .WithMany(p => p.Orders)
                .IsRequired()
                .HasForeignKey(p => p.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Orders)
                .IsRequired()
                .HasForeignKey(p => p.ProductId)
                .HasConstraintName("FK_Orders_Products");
        }
    }
}
