
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
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
              
                int TrainingProgramId = TrainingProgramService.FetchInputTrainingProgramIdService(trainingProgramRepository.GetAllTrainingProgram());

                var trainingProgram = trainingProgramRepository.GetTrainingProgram(TrainingProgramId);
                if (trainingProgram != null)
                {
                   EnrolledEmployeeService.FetchInputforEmployeeToEnrolledService(appDbContext, employeeRepository, enrolledEmployeeRepository,trainingProgram);
                }
                else
                {
                    Console.WriteLine("Training Prgram Not Found..");
                    return;

                }

                
            }
        }
        public static void UpdateTheScoreOfEnrolledEmployeeController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                EnrolledEmployeeRepository enrolledEmployeeRepository = new EnrolledEmployeeRepository(appDbContext);
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
                int TPID = 0;
                int ENID = 0;
                int Score = EnrolledEmployeeService.FetchInputScoreService(out TPID,out ENID,trainingProgramRepository.GetAllTrainingProgram());
                if(TPID !=0 )
                { 
                    enrolledEmployeeRepository.UpdateEnrolledEmployeeScore(TPID, ENID, Score);

                }
                else
                {

                }
            }

        }
       
    }
}
