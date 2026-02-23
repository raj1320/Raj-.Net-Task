using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CTMS.Repository.Data.Configurations
{
    public class TrainingProgramConfigure : IEntityTypeConfiguration<TrainingProgram>
    {
       public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {
            builder.ToTable("TrainingPrograms");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(100);
            
            builder.Property(x => x.DurationInDays)
                .IsRequired(true);

            builder.Property(x=>x.StartDate)
                .IsRequired(true);

            builder.HasMany(x => x.Scores)
                .WithOne(x => x.trainingProgram)
                .HasForeignKey(x => x.TrainingProgramId);
        }
    }
}

