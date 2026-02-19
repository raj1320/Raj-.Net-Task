using EFCoreDay1.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFWithRelationships.Data
{
    public class Batch
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int CourseId { get; set; }
        public int TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
