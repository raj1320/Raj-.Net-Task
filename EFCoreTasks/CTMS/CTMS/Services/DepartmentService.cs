using CTMS.Repository.Entities;
namespace CTMS.Services
{
    public class DepartmentService
    {
        public static Department FetchInputDepartmentService()
        {
            Department department = new Department();
           
            Console.WriteLine("Enter The Name Of The Department : "); 
            string Name = Console.ReadLine() ?? "Test";

            int Day = 0;
            int Month = 0;
            int Year = 0;
            Console.WriteLine("Enter The Date Of Establishment Of Department ,  ");
            GeneralService.FetchUserInputGeneric(ref Day, "Enter The Day of Month : ");
            GeneralService.FetchUserInputGeneric(ref Month, "Enter The Month : ");
            GeneralService.FetchUserInputGeneric(ref Year, "Enter The Year : ");

            Console.WriteLine("Enter The Description");
            string Desc= Console.ReadLine() ?? "Test";
            Console.WriteLine("Enter The Location");
            string Loacation = Console.ReadLine() ?? "Test";

            department.Name = Name;
            department.Description = Desc;
            department.DateOfEstablishment = new DateTime(Year, Month, Day);
            department.Location = Loacation;

            return department;
            
        }

        public static void ShowDepartmentService(List<Department> departments)
        {
            int num = departments.Count();
            foreach (Department dept in departments)
            {
                Console.WriteLine($"Id: {dept.Id} , Name: {dept.Name} , DateOfEstablishment : {dept.DateOfEstablishment} , Description : {dept.Description} , Location : {num}");
            }
        }

        public static int FetchInputDepartmentIdService(List<Department> listOfDepartment)
        {

            while (true)
            {
                ShowDepartmentService(listOfDepartment);
                string? Input;
                Console.WriteLine("Choose the desired Department Id:");
                Input = Console.ReadLine() ?? "0";

                int Idx = int.Parse(Input);
                foreach(Department dept in listOfDepartment)
                {
                    if(dept.Id == Idx)
                    {
                        return dept.Id;
                    }
                }
                Console.WriteLine("Please Enter Valid Id...");
            }
       
        }
       
        public static void ShowDepartStateDepartmentService(Department  department,List<Employee> employees)
        {
            
            var listOfEnrolledEmployee = employees.Where(x => x.Department.Id == department.Id && x.IsEnrolled == true);
            var listOfTrainerEmployee = employees.Where(x => x.Department.Id == department.Id && x.IsTrainer == true);

            Console.WriteLine($"\nDepartment : {department.Name} , Total Employees : {department.Employees.Count()} , Count of Employees Enrolled in Training : {listOfEnrolledEmployee.Count()} ,Count of  Trainer Employee in Department : {listOfTrainerEmployee.Count()}");

            EmployeeService.ShowEmployeeService(department.Employees);
        }

        
    }
}



