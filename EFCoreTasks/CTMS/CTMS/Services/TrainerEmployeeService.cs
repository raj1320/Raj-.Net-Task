
using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;

namespace CTMS.Services
{
    public class TrainerEmployeeService
    {
        public static List<TrainerEmployee> FetchInputForListOfTrainerService(TrainingProgram trainingProgram,TrainerEmployeeRepository trainerEmployeeRepository,List<Employee> employees)
        {
            string? Input;
            int size = employees.Count();
            List<Employee> ListOfEmployee=new List<Employee>();
            List<TrainerEmployee> trainerEmployees = new List<TrainerEmployee>();
            while (true)
            {
                int count = 1;
                Console.WriteLine("\nHere is the list of Employee");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"{count++}) Name : {employee.Name} , Designation : {employee.Designation} , Years of Experience :{employee.YearsOfExperties} ");
                }
                Console.WriteLine("Enter 1,2,3... for select Employee As a Trainer...");
                Input = Console.ReadLine();
                if (Input != null)
                {
                    try
                    {
                        var listOfChoice = Input.Trim().Split(',');
                        foreach (string choice in listOfChoice)
                        {
                            int idx = int.Parse(choice) - 1;
                            if (idx > 0 && idx <= size && employees[idx] != null)
                            {
                                ListOfEmployee.Add(employees[idx]);
                            }
                            else
                            {
                                Console.WriteLine("\nEnter Valid Input...");
                            }
                        }
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("\nEnter Valid Input...");

                    }

                }
            }

            foreach (Employee employee in employees)
            {
                TrainerEmployee trainerEmployee = new TrainerEmployee();
                employee.IsTrainer = true;
                trainerEmployee.EmployeeId = employee.Id;
                trainerEmployee.TrainingPrograms.Add(trainingProgram);
                trainerEmployeeRepository.AddTrainerEmployee(trainerEmployee);
            }

            return trainerEmployees;
        }
    }
}
