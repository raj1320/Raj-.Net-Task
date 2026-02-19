using Microsoft.EntityFrameworkCore;
namespace EFWithRelationships.Data
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
        public virtual List<Batch> Batches { get; set; } = new List<Batch>();

    }
}
