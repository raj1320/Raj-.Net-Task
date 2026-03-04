namespace EMS_Project.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int CreateBy { get; set; }
        public int? UpdatedBy { get; set; }

        public User EventCreator { get; set; } = null!;
        public User?EventUpdator { get; set; } = null!;

    }
}
