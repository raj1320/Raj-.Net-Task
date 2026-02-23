using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CTMS.Repository.Data.Configurations
{
     
    public class EnrolledEmployeeConfigure : IEntityTypeConfiguration<EnrolledEmployee>
    {
        public void Configure(EntityTypeBuilder<EnrolledEmployee> builder)
        {
            builder.ToTable("EnrolledEmployees");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.EmployeeId)
                .IsRequired(true);



            // --->  EnrolledEmployee is one Employee <---

            builder.HasOne(x => x.Employee)
                .WithOne(x => x.EnrolledEmployee)
                .HasForeignKey<EnrolledEmployee>(en => en.EmployeeId);


            // ---> many EnrolledEmployee has Many TrainerPrograms <---

            builder.HasMany(t=>t.TrainingPrograms)
                .WithMany(t=>t.EnrolledEmployees)
                .UsingEntity(j => j.ToTable("EnrolledEmployee_IN_TrainingPrograms"));


            builder.HasMany(x => x.Scores)
                .WithOne(x => x.enrolledEmployee)
                .HasForeignKey(x => x.EnrolledEmployeeId);


            
        }
    }
}
