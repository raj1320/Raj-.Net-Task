using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFWithRelationships.Data;

namespace EFCoreDay1.Configuration
{
    public class TrainerConfigur : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainers");
            builder.HasKey(t => t.Id);

            builder.Property(r => r.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(r=>r.ExperienceYears)
                .IsRequired(true);

            builder.HasMany(B => B.Batches)
                .WithOne(t => t.Trainer)
                .HasForeignKey(B => B.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);
              
                
        }
    }
}
