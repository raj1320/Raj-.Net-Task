
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

        public TrainingProgram? GetTrainingProgram(int Id)
        {
            var trainingProgram = _Context.TrainingPrograms.Include(x => x.EnrolledEmployees).ThenInclude(y => y.Employee).SingleOrDefault(x => x.Id == Id);
            return trainingProgram;
        }

        public List<TrainingProgram> GetAllTrainingProgram()
        {
            return _Context.TrainingPrograms.Include(x=>x.TrainerEmployees).ThenInclude(x=>x.Employee)
                                            .Include(x=>x.EnrolledEmployees).ThenInclude(x=>x.Employee).ToList();
        }
       
        private void ToggleTheflags(TrainingProgram trainingProgram, EnrolledEmployeeRepository enrolledEmployeeRepository, TrainerEmployeeRepository trainerEmployeeRepository)
        {
           
            List<int> ENID = new List<int>();
            List<int> TRID = new List<int>();
            if (trainingProgram != null)
            {
                foreach (var employee in trainingProgram.EnrolledEmployees)
                {
                    if (employee.TrainingPrograms.Count() == 1)
                    {
                        employee.Employee.IsEnrolled = false;
                        ENID.Add(employee.Id);
                        _Context.SaveChanges();
                    }
                    Console.WriteLine("Enrolled Employee Remove From Training Program");

                }
                if (ENID.Count()>0)
                {
                    for (int i = 0; i < ENID.Count(); i++)
                    {
                        enrolledEmployeeRepository.DeleteEnrolledEmployee(ENID[i]);
                        _Context.SaveChanges();
                    }
                }

                foreach (var employee in trainingProgram.TrainerEmployees)
                {
                    if (employee.TrainingPrograms.Count() == 1)
                    {
                        employee.Employee.IsTrainer = false;
                        TRID.Add(employee.Id);
                        _Context.SaveChanges();
                    }
                    Console.WriteLine("Trainer Employee Remove From Training Program");
                }

                if (TRID.Count()>0)
                {
                    for(int i = 0; i < TRID.Count(); i++)
                    {
                        trainerEmployeeRepository.DeleteTrainerEmployee(TRID[i]);
                        _Context.SaveChanges();
                    }
                }
            }

        }    
        
        public void DeleteTrainingProgram(int Id,EnrolledEmployeeRepository enrolledEmployeeRepository,TrainerEmployeeRepository trainerEmployeeRepository)
        {
            var trainingProgram = _Context.TrainingPrograms.Include(x => x.TrainerEmployees).ThenInclude(x => x.Employee)
                                                           .Include(x => x.EnrolledEmployees).ThenInclude(x => x.Employee).Include(x=>x.Scores)
                                                           .FirstOrDefault(x => x.Id == Id);



            if (trainingProgram != null)
            {
               trainingProgram.Scores.RemoveAll(x=>x.trainingProgram.Id==trainingProgram.Id);
                
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
