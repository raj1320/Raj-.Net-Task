
using EFWithRelationships.Data;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDay1.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Column(TypeName="decimal(10,2)")]
        public double Fees { get; set; } 
        
        public int DurationInMonths { get; set; } 

        public List<Batch> Batches { get; set; } = new List<Batch>();

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
