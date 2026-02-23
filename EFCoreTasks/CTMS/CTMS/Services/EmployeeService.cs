using CTMS.Repository.Entities;
using System.Drawing;


namespace CTMS.Services
{
    public class EmployeeService
    {
       public static Employee?  FetchEmloyeeFromUserService(int id,List<string> EmailList)
        {
            Console.WriteLine("Enter The Name of the Employee:");
            string Name = Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Email of the Employee:");
            string Email = Console.ReadLine() ?? "Test";
            foreach (string email in EmailList) 
            {
                if (email == Email) 
                {
                    Console.WriteLine("Email already Exist..");
                    Console.WriteLine("Try again");
                    return null;
                }
            }
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
            employee.DepartmentId = id;
            employee.YearsOfExperties = Experience;
            return employee;
        }

        public static void ShowEmployeeService(List<Employee> listOfEmployee)
        {
            foreach (Employee emp in listOfEmployee) 
            {
                Console.WriteLine($"Id : {emp.Id},\nName: {emp.Name}, Email: {emp.Email},\nPhone Number: {emp.PhoneNumber} , Address : {emp.Address} ,\nDesignation: {emp.Designation} , Salary : {emp.Salary} ,\nDepartment : {emp.Department.Name} , YearOfExperience : {emp.YearsOfExperties}\n");
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
            
                ShowEmployeeService(listOfEmployee);

                GeneralService.FetchUserInputGeneric(ref Id, "Choose the desired index:");

                foreach(Employee emp in listOfEmployee)
                {
                    if (emp.Id == Id)
                    {
                        return Id;
                    }
                }

            return 0;
           
        }
        
    }
}

