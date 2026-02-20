
namespace CTMS.Repository.Entities
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfEstablishment { get; set; }
        public string Description { get; set; }= string.Empty;

        public List<Employee> Employees { get; set; } = new List<Employee>();
        
    }
}
