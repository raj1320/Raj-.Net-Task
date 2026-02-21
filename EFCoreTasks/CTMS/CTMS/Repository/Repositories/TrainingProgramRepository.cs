
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTMS.Repository.Repositories
{
    public class TrainingProgramRepository
    {
        AppDbContext _Context;
        public TrainingProgramRepository(AppDbContext appDbContext) 
        {
            _Context = appDbContext;
        }

        public void AddTrainingProgram(TrainingProgram trainingProgram )
        {
            _Context.TrainingPrograms.Add( trainingProgram );
            _Context.SaveChanges();
            Console.WriteLine("Traininng Program Added Successfully...");
        }

        public List<TrainingProgram> GetAllTrainingProgram()
        {
            return _Context.TrainingPrograms.Include(x=>x.TrainerEmployees).ThenInclude(x=>x.Employee)
                                            .Include(x=>x.EnrolledEmployees).ThenInclude(x=>x.Employee).ToList();
        }
        private void ToggleTheflags(TrainingProgram trainingProgram, EnrolledEmployeeRepository enrolledEmployeeRepository, TrainerEmployeeRepository trainerEmployeeRepository)
        {
            
            if (trainingProgram != null)
            {
                var listOfEnrolledEmployees = trainingProgram.EnrolledEmployees.ToList();
                var listOfTrainerEmployees = trainingProgram.TrainerEmployees.ToList();

                var OthertrainingProgram = _Context.TrainingPrograms.Include(x => x.TrainerEmployees).ThenInclude(x => x.Employee)
                                                                     .Include(x => x.EnrolledEmployees).ThenInclude(x => x.Employee)
                                                                     .Where(x => x.Id == trainingProgram.Id).ToList();

                HashSet<int> TemployeeIdList = new HashSet<int>();
                HashSet<int> EemployeeIdList = new HashSet<int>();

                foreach (var trainerEmployee in OthertrainingProgram)
                {
                    foreach (var Employee in trainerEmployee.TrainerEmployees)
                    {
                        TemployeeIdList.Add(Employee.EmployeeId);

                    }
                }

                foreach (var enrolledEmployee in OthertrainingProgram)
                {
                    foreach (var Employee in enrolledEmployee.EnrolledEmployees)
                    {
                        EemployeeIdList.Add(Employee.EmployeeId);

                    }
                }

                foreach (var item in listOfEnrolledEmployees)
                {
                    if (!EemployeeIdList.Contains(item.EmployeeId))
                    {
                        item.Employee.IsEnrolled = false;
                        enrolledEmployeeRepository.DeleteEnrolledEmployee(item.Id);
                        _Context.SaveChanges();
                    }
                }

                foreach (var item in listOfTrainerEmployees)
                {
                    if (!TemployeeIdList.Contains(item.EmployeeId))
                    {
                        item.Employee.IsTrainer = false;
                        trainerEmployeeRepository.DeleteTrainerEmployee(item.Id);
                        _Context.SaveChanges();
                    }
                }

            }

        }
    
        public void DeleteTrainingProgram(int Id,EnrolledEmployeeRepository enrolledEmployeeRepository,TrainerEmployeeRepository trainerEmployeeRepository)
        {
            var trainingProgram = _Context.TrainingPrograms.Include(x => x.TrainerEmployees).ThenInclude(x => x.Employee)
                                                           .Include(x => x.EnrolledEmployees).ThenInclude(x => x.Employee)
                                                           .FirstOrDefault(x => x.Id == Id);

            if (trainingProgram != null)
            {
                ToggleTheflags(trainingProgram,enrolledEmployeeRepository,trainerEmployeeRepository);
                _Context.TrainingPrograms.Remove(trainingProgram);
                _Context.SaveChanges();
                Console.WriteLine("TrainingProgram is Remove From the Training Program");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }

    }
}
