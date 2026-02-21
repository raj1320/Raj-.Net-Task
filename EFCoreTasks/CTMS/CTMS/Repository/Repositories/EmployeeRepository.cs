
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTMS.Repository.Repositories
{
    public class EmployeeRepository
    {
        public AppDbContext _Context { get; set; }
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        public void AddEmployee(Employee employee)
        {
              _Context.Employees.Add(employee);
              _Context.SaveChanges();
               Console.WriteLine("Employee Added Successfully...");
        }

        public Employee? GetEmployee(int Id)
        {
            var employee = _Context.Employees.Include(x=>x.Department).FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public List<Employee> GetAllEmployee()
        {
            var listOfEmployee = _Context.Employees.Include(x => x.Department).ToList();
            return listOfEmployee;
        }


        public void UpdateEmployeeSalary(int Id, double Salary)
        {
            var employee = GetEmployee(Id);
            if (employee != null)
            {
                employee.Salary = Salary;
                _Context.SaveChanges();
                Console.WriteLine("Employee Updated Successfully...");
            }
            else
            {
                Console.WriteLine("Employee is Not Found");
            }
            
        }

        public void UpdateEmployeeDepartmentId(int Id,int DeptId)
        {
            var employee = GetEmployee(Id);
            if (employee != null)
            {
                employee.DepartmentId = DeptId;
                _Context.SaveChanges();
                Console.WriteLine("Employee Department is Updated Successfully..");
            }
            else
            {
                Console.WriteLine("Employee is Not Found");
            }
            
        }

        public void DeleteEmployee(int Id)
        {
            var employee = GetEmployee(Id);
            if (employee != null)
            {
                _Context.Employees.Remove(employee);
                _Context.SaveChanges();
                Console.WriteLine("Employee is Remove Successfully");
            }
            else Console.WriteLine("Record Not Found...");
        }


    }
}
