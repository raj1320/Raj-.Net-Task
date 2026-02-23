
namespace CTMS.Repository.Entities
{
    public class TrainingProgram
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }

        public List<TrainerEmployee> TrainerEmployees { get; set; }= new List<TrainerEmployee>();
        public List<EnrolledEmployee> EnrolledEmployees { get; set;}= new List<EnrolledEmployee>();

        public List<Score> Scores { get; set; } = new List<Score>();
    }
}
