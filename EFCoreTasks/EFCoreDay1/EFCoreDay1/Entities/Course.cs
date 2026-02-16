
using Microsoft.Identity.Client;

namespace EFCoreDay1.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Double Fees { get; set; } 
        public int DurationInMonths { get; set; } 
    }
}
