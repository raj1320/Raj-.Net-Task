
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreDay1.Entities
{
    public class Student 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100),Required]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(50),EmailAddress,Required]
        public string Email { get; set; } = string.Empty;        
        public DateTime Created { get; set; }

        public virtual List<Course> Courses { get; set; } = new List<Course>();

        
        
    }
}


