
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;
using CTMS.Services;

namespace CTMS.Controller
{
    public class DepartmentController
    {
        public static void AddDepartmentController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(appDbContext);
                var department = DepartmentService.FetchInputDepartmentService();
                 departmentRepository.AddDepartment(department);
            }
        }

        

        public static void ShowDepartmentStatesticController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(appDbContext);
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                int departmentId = DepartmentService.FetchInputDepartmentIdService(departmentRepository.GetAllDepartment());
                var department = departmentRepository.GetDepartment(departmentId);
                if(department == null)
                {
                    Console.WriteLine("No Record Found");
                    return;
                }
                DepartmentService.ShowDepartStateDepartmentService(department,employeeRepository.GetAllEmployee());
            }
        }

        public static void DeleteDepartmentController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(appDbContext);
                int departmentId =DepartmentService.FetchInputDepartmentIdService(departmentRepository.GetAllDepartment());
                departmentRepository.DeleteDepartment(departmentId);
            }
        }
    }
}
