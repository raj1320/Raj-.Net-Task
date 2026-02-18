using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDay1.Configuration
{
    public class BatchesConfigur : IEntityTypeConfiguration<Batch> 
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batches");
            builder.HasKey(x => x.Id);
            builder.Property(r => r.StartDate)
                .IsRequired(true);

            builder.Property(r=>r.TrainerId)
                .IsRequired(true);

            builder.Property(r=>r.CourseId)
                .IsRequired(true);

            builder.HasOne(b => b.Trainer)
                .WithMany(t => t.Batches)
                .HasForeignKey(b => b.TrainerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b=>b.Course)
                .WithMany(c=>c.Batches)
                .HasForeignKey(b=>b.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
