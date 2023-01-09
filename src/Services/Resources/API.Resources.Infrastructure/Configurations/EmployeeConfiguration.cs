using API.Resources.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Resources.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(name: "Employees");
            builder.HasKey(x => x.Id)
                .HasName(name: "PK_Employees");

            builder.Property(p => p.Id)
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.LastName)
                .IsRequired(false)
                .HasColumnType("nvarchar(50)");

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.DateOfJoining)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.Gender)
                .IsRequired()
                .HasColumnType("integer");


        }
    }
}
