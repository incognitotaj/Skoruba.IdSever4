using API.Resources.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Resources.Infrastructure.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable(name: "Subscriptions");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_Subscriptions");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(x => x.StartDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.EndDate)
                .IsRequired(false)
                .HasColumnType("date");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("integer");

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.Subscriptions)
                .HasConstraintName("FK_subsciptions_Employee")
                .IsRequired()
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
