using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;
using CTMS.Services;

namespace CTMS.Controller
{
    public class EmployeeController
    {
        public static void AddEmployeeController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                var employee = EmployeeService.FetchEmloyeeFromUserService();
                employeeRepository.AddEmployee(employee);
            };

        }
        public static void ShowEmployeesController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                List<Employee> listOfEmployee = employeeRepository.GetAllEmployee();
                EmployeeService.ShowEmployeeService(listOfEmployee);
            };
        }

        public static void UpdateEmployeeSalaryContoller()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                int EmployeeId;
                double salary= EmployeeService.FetchEmployeeSalaryService(out EmployeeId,employeeRepository.GetAllEmployee());
                employeeRepository.UpdateEmployeeSalary(EmployeeId, salary);
            };
        }

        public static void DeleteEmployeeContoller() 
        {
            using(AppDbContext appDbContext = new AppDbContext())
            {
                EmployeeRepository employeeRepository= new EmployeeRepository(appDbContext);
                int EmployeeId=EmployeeService.FetchEmployeeId(employeeRepository.GetAllEmployee());
                employeeRepository.DeleteEmployee(EmployeeId);
            };
          
        }
    
    }
}
