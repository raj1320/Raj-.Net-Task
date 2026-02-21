
namespace CTMS.Repository.Entities
{
    public class EnrolledEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Score { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();

        public Employee Employee { get; set; } = null!;
    }
}
