using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CTMS.Repository.Data.Configurations
{
    public class DepartmentConfigure : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(x => x.DateOfEstablishment)
                    .IsRequired(true);

            builder.Property(x => x.Description)
                   .HasMaxLength(300);

            builder.Property(x => x.Location)
                    .HasMaxLength(100);

            // ---> Department has Many Employee <---

            builder.HasMany(D => D.Employees)
                   .WithOne(E => E.Department)
                   .HasForeignKey(E => E.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);



            builder.HasData(
                new Department { Id = 1, Name = "IT", DateOfEstablishment = new DateTime(2021, 1, 1), Description = "Produce Valuable Software", Location = "3rd-floor" },
                new Department { Id = 2, Name = "Salse", DateOfEstablishment = new DateTime(2021, 3, 1), Description = "Produce Valuable Software", Location = "3rd-floor" },
                new Department { Id = 3, Name = "Marketing", DateOfEstablishment = new DateTime(2022, 1, 1), Description = "Produce Valuable Software", Location = "3rd-floor" },
                new Department { Id = 4, Name = "QA", DateOfEstablishment = new DateTime(2023, 1, 1), Description = "Produce Valuable Software", Location = "3rd-floor" },
                new Department { Id = 5, Name = "Finance", DateOfEstablishment = new DateTime(2021, 1, 1), Description = "Produce Valuable Software", Location = "3rd-floor" }
              );
        }
    }
}
