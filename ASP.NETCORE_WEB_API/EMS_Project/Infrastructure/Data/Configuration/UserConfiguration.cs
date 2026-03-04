using EMS_Project.Domain.Entities;
using EMS_Project.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EMS_Project.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> Builder)
        {
            Builder.ToTable("Users");
            Builder.HasKey(x => x.Id);
            
            Builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);
            
            Builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired(true);

            Builder.HasIndex(x => x.Email)
                .IsUnique(true);
            
            Builder.Property(x => x.PasswordHash)
                .HasMaxLength(100)
                .IsRequired(true);
            
            Builder.Property(x => x.Role)
                .IsRequired(true);


        

        }
    }
}
