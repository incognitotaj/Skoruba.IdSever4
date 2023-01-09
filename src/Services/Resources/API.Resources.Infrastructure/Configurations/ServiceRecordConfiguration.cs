using API.Resources.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Resources.Infrastructure.Configurations
{
    public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
    {
        public void Configure(EntityTypeBuilder<ServiceRecord> builder)
        {
            builder.ToTable(name: "ServiceRecords");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_ServiceRecords");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Employer)
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
                .WithMany(p => p.ServiceRecords)
                .HasConstraintName("FK_ServiceRecords_Employee")
                .IsRequired()
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
