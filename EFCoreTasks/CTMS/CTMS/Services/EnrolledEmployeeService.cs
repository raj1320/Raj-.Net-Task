

using CTMS.Repository.Entities;
using CTMS.Repository.Repositories;
using System.Collections;

namespace CTMS.Services
{
    public class EnrolledEmployeeService
    {
        public static List<EnrolledEmployee> FetchInputforEmployeeToEnrolledService(EmployeeRepository employeeRepository, EnrolledEmployeeRepository  enrolledEmployeeRepository , TrainingProgram trainingProgram)
        {
            List<Employee> employees = employeeRepository.GetAllEmployee();
            string? Input;
            int size = employees.Count();
            List<Employee> ListOfEmployee = new List<Employee>();
            List<EnrolledEmployee> enrolledEmployees = new List<EnrolledEmployee>();
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

            
            Dictionary<int,List<TrainingProgram>> enrolledEmployeeslist = enrolledEmployeeRepository.GetAllEnrolledEmployee().Select(x=>new { x.EmployeeId,x.TrainingPrograms }).ToDictionary(x=>x.EmployeeId,x=>x.TrainingPrograms);
            Dictionary<int,int> idlist = enrolledEmployeeRepository.GetAllEnrolledEmployee().Select(x=>new { x.EmployeeId,x.Id }).ToDictionary(x=>x.EmployeeId,x=>x.Id);
            foreach (Employee employee in employees)
            {
                if (enrolledEmployeeslist.ContainsKey(employee.Id))
                {
                    enrolledEmployeeRepository.AddTrainingProgrm(idlist[employee.Id], trainingProgram);
                }
                else
                {
                    EnrolledEmployee enrolledEmployee = new EnrolledEmployee();
                    employee.IsEnrolled = true;
                    enrolledEmployee.EmployeeId = employee.Id;
                    enrolledEmployee.TrainingPrograms.Add(trainingProgram);
                    enrolledEmployeeRepository.AddEnrolledEmployee(enrolledEmployee);
                }
                
            }

            return enrolledEmployees;
        }

        
        public static int FetchInputScoreService(out int Id,List<TrainingProgram> trainingPrograms)
        {
            Id=TrainingProgramService.FetchInputTrainingProgramIdService(trainingPrograms);
            int Score = 0;
            GeneralService.FetchUserInputGeneric(ref Score, "Enter The Current Score of Employee");
            return Score;

        }


    }
}
