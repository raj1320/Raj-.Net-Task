
using CTMS.Repository.Data;
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
                var ListOfDepartments = departmentRepository.GetAllDepartment();
                DepartmentService.ShowDepartStateDepartmentService(ListOfDepartments);
            }
        }

        public static void ShowTrainingDepartmentDetailsController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(appDbContext);
                var ListOfDepartments = departmentRepository.GetAllDepartment();
               DepartmentService.ShowDepartStateDepartmentService(ListOfDepartments);
            }
        }

        public static void DeleteDepartmentController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                DepartmentRepository departmentRepository = new DepartmentRepository(appDbContext);
                int departmentId =DepartmentService.FetchInputDepartmentIdService();
                departmentRepository.DeleteDepartment(departmentId);
            }
        }
    }
}
