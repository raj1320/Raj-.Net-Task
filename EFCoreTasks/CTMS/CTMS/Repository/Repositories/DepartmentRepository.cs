
using CTMS.Repository.Data;
using CTMS.Repository.Entities;

namespace CTMS.Repository.Repositories
{
    public class DepartmentRepository
    {
        public AppDbContext _Context { get; set; }
        public DepartmentRepository(AppDbContext appDbContext) 
        {
          _Context = appDbContext;
        }

        public void AddDepartment(Department department)
        {
            _Context.Departments.Add(department);
            if(department!=null)
            _Context.SaveChanges();
            Console.WriteLine("Department Added Successfully..");
        }


        public Department? GetDepartment(int Id)
        {
            var department = _Context.Departments.FirstOrDefault(x => x.Id == Id);
            return department;
        }

        public List<Department> GetAllDepartment()
        {
            var listOfDepartments = _Context.Departments.ToList();
            return listOfDepartments;
        }

        public void DeleteDepartment(int Id)
        {
            var department = GetDepartment(Id);
            if (department != null)
            {
                _Context.Departments.Remove(department);
                _Context.SaveChanges();
                Console.WriteLine("Employee is Remove Successfully");
            }

            else Console.WriteLine("Record Not Found...");
        }


    }
}
