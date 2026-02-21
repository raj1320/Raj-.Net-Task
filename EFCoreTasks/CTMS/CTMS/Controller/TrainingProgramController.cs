
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;
using CTMS.Services;

namespace CTMS.Controller
{
    public class TrainingProgramController
    {
        public static void AddTrainingProgramController()
       {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
                TrainerEmployeeRepository trainerEmployeeRepository = new TrainerEmployeeRepository(appDbContext);
                TrainingProgram trainingProgram = TrainingProgramService.FetchInputForTrainingProgramService();
                
                EmployeeRepository employeeRepository = new EmployeeRepository(appDbContext);
                List<TrainerEmployee> trainerList =TrainerEmployeeService.FetchInputForListOfTrainerService(trainingProgram, trainerEmployeeRepository, employeeRepository.GetAllEmployee()); 

                trainingProgram.TrainerEmployees= trainerList;
                trainingProgramRepository.AddTrainingProgram(trainingProgram);
            };

        }

        public static void ShowTrainingProgramController()
        {
            using(AppDbContext appDbContext = new AppDbContext())
            {
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
                TrainingProgramService.ShowTrainingPrograms(trainingProgramRepository.GetAllTrainingProgram());
            };
        }
      
        public static void DeleteTrainingProgramController() 
        {
            using(AppDbContext appDbContext = new AppDbContext())
            {
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository(appDbContext);
                TrainerEmployeeRepository trainerEmployeeRepository = new TrainerEmployeeRepository(appDbContext);
                EnrolledEmployeeRepository enrolledEmployeeRepository = new EnrolledEmployeeRepository(appDbContext);
                
                int Id = TrainingProgramService.FetchInputTrainingProgramIdService(trainingProgramRepository.GetAllTrainingProgram());
                
                trainingProgramRepository.DeleteTrainingProgram(Id,enrolledEmployeeRepository, trainerEmployeeRepository);
                
            };

        
        }
    }
}
