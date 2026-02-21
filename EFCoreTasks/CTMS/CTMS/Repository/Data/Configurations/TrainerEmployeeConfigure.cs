using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CTMS.Repository.Data.Configurations
{
    public  class TrainerEmployeeConfigure : IEntityTypeConfiguration<TrainerEmployee>
    {
        public void Configure(EntityTypeBuilder<TrainerEmployee> builder)
        {
            builder.ToTable("TrainerEmployees");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmployeeId)
                .IsRequired(true);


            // --->  TrainerEmployee is one Employee <---

            builder.HasOne(x => x.Employee)
                .WithOne(t => t.TrainerEmployee)
                .HasForeignKey<TrainerEmployee>(t => t.EmployeeId);


            // ---> many TrainingPrograms has Many trainerEmployee <---

            builder.HasMany(t => t.TrainingPrograms)
                .WithMany(x => x.TrainerEmployees)
                .UsingEntity(j => j.ToTable("TrainingPrograms_With_TrainerEmployee"));


        }
    }
}
