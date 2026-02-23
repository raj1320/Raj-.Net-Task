using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CTMS.Repository.Entities;
namespace CTMS.Repository.Data.Configurations
{
    public class ScoreConfigure : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Scores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ScoreValue)
                .HasDefaultValue(0);

         
              

        }
    }
}
