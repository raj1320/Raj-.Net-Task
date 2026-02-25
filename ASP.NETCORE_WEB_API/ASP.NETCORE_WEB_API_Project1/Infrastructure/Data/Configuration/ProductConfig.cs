using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NETCORE_WEB_API_Project1.Infrastructure.Data.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsAvailable)
                .HasDefaultValue(true);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(10, 2)");

            builder.Property(x=>x.Category)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x=>x.VandorName)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(x => x.Stock)
               .IsRequired(true);
        }
    }
}
