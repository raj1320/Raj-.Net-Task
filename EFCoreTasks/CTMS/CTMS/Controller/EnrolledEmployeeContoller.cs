
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;
using CTMS.Services;

namespace CTMS.Controller
{
    public class EnrolledEmployeeContoller
    {
        public static void EnrollEmployeeToTrainingProgramController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                EnrolledEmployeeRepository enrolledEmployeeRepository = new EnrolledEmployeeRepository(appDbContext);
                
                EnrolledEmployee  enrolledEmployee=EnrolledEmployeeService.FetchInputforEmployeeToEnrolledService(employeeRepository, enrolledEmployeeRepository, trainingProgram);
                enrolledEmployeeRepository.AddEnrolledEmployee(enrolledEmployee);
            }

        }
        public static void UpdateTheScoreOfEnrolledEmployeeController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EnrolledEmployeeRepository enrolledEmployeeRepository = new EnrolledEmployeeRepository(appDbContext);
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
                int Id = 0;
                int Score = EnrolledEmployeeService.FetchInputScoreService(out Id,trainingProgramRepository.GetAllTrainingProgram());
                enrolledEmployeeRepository.UpdateEnrolledEmployeeScore(Id,Score);
            }

        }
       
    }
}
