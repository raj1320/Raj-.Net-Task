
namespace CTMS.Repository.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string PhoneNumber { get; set; }= string.Empty;
        public string Address { get; set; }=string.Empty;
        public Double Salary {  get; set; }
        public string Designation { get; set; } = string.Empty;
        public bool IsTrainer { get; set; }=false;
        public int DepartmentId { get; set; }
        public int YearsOfExperties { get; set; }

        public Department Department { get; set; } = null!;
    }
}
