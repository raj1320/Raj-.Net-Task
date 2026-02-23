
namespace CTMS.Repository.Entities
{
    public class EnrolledEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();

        public List<Score> Scores { get; set; }= new List<Score>();

        public Employee Employee { get; set; } = null!;
    }
}
