using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CTMS.Repository.Data.Configurations
{
    public class EmployeeConfigure : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                    .IsRequired(true)
                    .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                   .IsUnique(true);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.Address)
                    .IsRequired(true)
                    .HasMaxLength(100);

            builder.Property(x => x.Salary)
                   .HasColumnType("decimal(10,2)");

            builder.Property(x => x.IsTrainer)
                   .HasDefaultValue(false);

            builder.Property(x => x.IsEnrolled)
                   .HasDefaultValue(false);

            builder.Property(x => x.YearsOfExperties)
                   .IsRequired(true);

            builder.Property(x => x.Designation)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.DepartmentId)
                .IsRequired(true);

            
            
        }
    }
}
