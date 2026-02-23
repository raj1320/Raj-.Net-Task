

using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;


namespace CTMS.Services
{
    public class EnrolledEmployeeService
    {
        public static void FetchInputforEmployeeToEnrolledService(AppDbContext appDbContext,EmployeeRepository employeeRepository, EnrolledEmployeeRepository  enrolledEmployeeRepository , TrainingProgram trainingProgram)
        {
                 List<Employee> employees = employeeRepository.GetAllEmployee();                      
                Console.WriteLine("\nHere is the list of Employee");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"ID :{employee.Id}) Name : {employee.Name} , Designation : {employee.Designation} , Years of Experience :{employee.YearsOfExperties} ");
                }
                Console.WriteLine("Select Employee Enter Id ...");
                int Id = int.Parse(Console.ReadLine() ?? "0");
                var TPEnrolledList = trainingProgram.EnrolledEmployees.ToList();
               
                foreach (var item in TPEnrolledList)
                {
                    
                    if(item.EmployeeId == Id)
                    {
                      Console.WriteLine("You are Already Enrolled..");
                        return;
                    }
                    
                }

                foreach(var item in enrolledEmployeeRepository.GetAllEnrolledEmployee())
                {
                    if(item.EmployeeId == Id)
                    {
                    item.TrainingPrograms.Add(trainingProgram);
                    Score score1 = new Score();
                    score1.TrainingProgramId = trainingProgram.Id;
                    score1.EnrolledEmployeeId= item.Id;
                    item.Scores.Add(score1);
                    trainingProgram.Scores.Add(score1);
                    trainingProgram.EnrolledEmployees.Add(item);
                    appDbContext.SaveChanges();
                    Console.WriteLine("Employee Enrolled Successfully...");
                    return;
                    }

                }

                EnrolledEmployee enrolledEmployee = new EnrolledEmployee();
                Score score = new Score();
                enrolledEmployee.EmployeeId = Id;
                enrolledEmployee.TrainingPrograms.Add(trainingProgram);
                enrolledEmployeeRepository.AddEnrolledEmployee(enrolledEmployee);
                score.EnrolledEmployeeId = enrolledEmployee.Id;
                score.TrainingProgramId= trainingProgram.Id;
                appDbContext.SaveChanges();
                enrolledEmployee.Scores.Add(score);
                trainingProgram.Scores.Add(score);
                enrolledEmployee.Employee.IsEnrolled = true;
                appDbContext.SaveChanges();

            return;
         
        }

        public static void ShowTrainingProgramEnrolledEmployee(TrainingProgram trainingProgram)
        {
            Console.WriteLine("Here is the list of Training Program Enrolled Employee");
            Console.WriteLine("========================================================");

            if (trainingProgram == null || trainingProgram.EnrolledEmployees.Count() == 0)
            {
                Console.WriteLine("Empty Records");

            }
            if (trainingProgram != null)
            {
                foreach (var Trainer in trainingProgram.EnrolledEmployees)
                {
                    Console.WriteLine($"Id: {Trainer.Id}) Trainer Name : {Trainer.Employee.Name} , Trainer Year Of Experience : {Trainer.Employee.YearsOfExperties}");
                }

            }

        }

        public static int FetchTheEnrolledEmployeeId(TrainingProgram trainingProgram)
        {
        
            int Id = 0;
             
            while (true)
            {
                
                ShowTrainingProgramEnrolledEmployee(trainingProgram);
                GeneralService.FetchUserInputGeneric(ref Id, "Choose the desired index:");

               foreach (var item in trainingProgram.EnrolledEmployees)
               {
                  if (item.Id == Id)
                  {
                     return Id;
                            
                  }
               }
            }
                   
        }

        public static int FetchInputScoreService(out int Id,out int ENID,List<TrainingProgram> trainingPrograms)
        {
            Id=TrainingProgramService.FetchInputTrainingProgramIdService(trainingPrograms);
            int TPID = Id;
            var result = trainingPrograms.FirstOrDefault(x=>x.Id==TPID);
            if (result != null)
            {
                ENID = FetchTheEnrolledEmployeeId(result);
                int Score = 0;
                GeneralService.FetchUserInputGeneric(ref Score, "Enter The new Score of Employee");
                return Score;

            }
            else
            {
                TPID = 0; 
                ENID = 0;
                Console.WriteLine("No Training program found");
                return 0;
            }

        }


    }
}
