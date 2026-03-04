using EMS_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS_Project.Infrastructure.Data.Configuration
{
    public class RegisteredConfiguration : IEntityTypeConfiguration<RegisteredEvent>
    {
        public void Configure(EntityTypeBuilder<RegisteredEvent> Builder)
        {
            Builder.ToTable("RegisteredEvents");
            
            Builder.HasKey(t => t.Id);

            Builder.HasOne(x=>x.User)
            .WithMany(x => x.RegisteredEvent)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            Builder.HasOne(x=>x.Event)
            .WithMany()
            .HasForeignKey(x => x.EventId);

        }
    }
}
