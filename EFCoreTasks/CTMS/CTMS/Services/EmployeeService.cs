using CTMS.Repository.Entities;
using System.Drawing;


namespace CTMS.Services
{
    public class EmployeeService
    {
       public static Employee  FetchEmloyeeFromUserService()
        {
            Console.WriteLine("Enter The Name of the Employee:");
            string Name = Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Email of the Employee:");
            string Email = Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Phone Number of the Employee:");
            string Phone = Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Address of the Employee:");
            string Address = Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Designation of the Employee:");
            string Designation = Console.ReadLine() ?? "Test";

            double Salary = 0;
            GeneralService.FetchUserInputGeneric(ref Salary, "Enter The Salary of the Employee");

            int Experience = 0;
            GeneralService.FetchUserInputGeneric(ref Experience, "Enter The Experience of the Employee");

            Employee employee = new Employee();
            employee.Name = Name;
            employee.Email = Email;
            employee.PhoneNumber = Phone;
            employee.Address = Address;
            employee.Designation = Designation;
            employee.Salary = Salary;

            return employee;
        }

        public static void ShowEmployeeService(List<Employee> listOfEmployee)
        {
            foreach (Employee emp in listOfEmployee) 
            {
                Console.WriteLine($"Name: {emp.Name} , Email: {emp.Email} , Phone Number: {emp.PhoneNumber} , Address : {emp.Address} , Designation: {emp.Designation} , Salary : {emp.Salary} , Department : {emp.Department.Name} , YearOfExperience : {emp.YearsOfExperties}");
            }
        }

        public static double FetchEmployeeSalaryService(out int Id,List<Employee> listOfEmployee)
        {
            Id = FetchEmployeeId(listOfEmployee);
            
            double salary = 0;
            GeneralService.FetchUserInputGeneric(ref salary, "Enter the new Salary");
            return salary;
        }

        public static int FetchEmployeeId(List<Employee> listOfEmployee)
        {
            int Id = 0;
            int flag = 0;
            while (flag != 1)
            {
                ShowEmployeeService(listOfEmployee);
                string? Input;
                Console.WriteLine("Choose the desired index:");
                Input = Console.ReadLine() ?? "0";

                int idx = int.Parse(Input);
                int size = listOfEmployee.Count();
                foreach (var employee in listOfEmployee)
                {

                    if (idx > 0 && idx <= size && listOfEmployee[idx] != null)
                    {
                        Id = employee.Id;
                        flag = 1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nEnter Valid Input...");
                    }
                }
            }
            return Id;

        }
        
    }
}

