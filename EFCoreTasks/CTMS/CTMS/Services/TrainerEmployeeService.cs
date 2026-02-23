
using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;

namespace CTMS.Services
{
    public class TrainerEmployeeService
    {
        public static void FetchInputForListOfTrainerService(AppDbContext appDbContext,TrainingProgram trainingProgram,TrainerEmployeeRepository trainerEmployeeRepository,List<Employee> employees)
        {

            string choice = "Y";
           
            while(choice!="N" && choice != "n")
            {
                int flag = 0;
                Console.WriteLine("\nHere is the list of Employee");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"ID :{employee.Id}) Name : {employee.Name} , Designation : {employee.Designation} , Years of Experience :{employee.YearsOfExperties} ");
                }
                Console.WriteLine("Select Trainer Id ...");
                int Id = int.Parse(Console.ReadLine() ?? "0");

                var TTPList = trainingProgram.TrainerEmployees.ToList();

                foreach (var item in TTPList)
                {

                    if (item.EmployeeId == Id)
                    {
                        Console.WriteLine("\nTrainer Already Present in Program..\n");
                        flag = 1;
                        Console.WriteLine("Do you Want to Add more Trainer");
                        choice = Console.ReadLine() ?? "Y";
                        break;
                    }

                }

               if(flag != 1)
                {
                    foreach (var item in trainerEmployeeRepository.GetAllTrainerEmployee())
                    {
                        if (item.EmployeeId == Id)
                        {
                            item.TrainingPrograms.Add(trainingProgram);
                            trainingProgram.TrainerEmployees.Add(item);
                            appDbContext.SaveChanges();
                            Console.WriteLine("\nTrainer added Successfully...\n");
                            flag = 1;
                            Console.WriteLine("Do you Want to Add more Trainer");
                            choice = Console.ReadLine() ?? "Y";
                            break;
                        }

                    }
                }

                if (flag != 1)
                {
                    TrainerEmployee trainerEmployee = new TrainerEmployee();
                    trainerEmployee.EmployeeId = Id;
                    trainerEmployee.TrainingPrograms.Add(trainingProgram);
                    appDbContext.TrainerEmployees.Add(trainerEmployee);
                    appDbContext.SaveChanges();
                    trainingProgram.TrainerEmployees.Add(trainerEmployee);
                    trainerEmployee.Employee.IsTrainer = true;
                    appDbContext.SaveChanges();

                    Console.WriteLine("\nTrainer Added Successfully...\n");
                    Console.WriteLine("Do you Want to Add more Trainer");
                    choice = Console.ReadLine() ?? "Y";
                }
            }

            
        }
    }
}
