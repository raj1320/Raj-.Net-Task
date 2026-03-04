using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EMS_Project.Domain.Entities;
namespace EMS_Project.Infrastructure.Data.Configuration
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> Builder)
        {
            Builder.ToTable("Events");
            Builder.HasKey(x => x.Id);

            Builder.Property(x => x.Name)
                .IsRequired(true)
                .HasMaxLength(100);

            Builder.Property(x => x.Description)
                .IsRequired(false)
               .HasMaxLength(100);
            
            Builder.Property(x => x.Location)
                .IsRequired(true)
               .HasMaxLength(100);

            Builder.Property(x => x.StartDate)
                .IsRequired(true);

            Builder.Property(x => x.EndDate)
                .IsRequired(true);

            Builder.HasOne(x => x.EventCreator)
                .WithMany(x => x.CreatedEvents)
                .HasForeignKey(x => x.CreateBy)
                .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(x => x.EventUpdator)
                .WithMany(x => x.UpdatedEvents)
                .HasForeignKey(x => x.UpdatedBy)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            

        }
    }
}
