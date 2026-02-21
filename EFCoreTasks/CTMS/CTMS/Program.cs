// See https://aka.ms/new-console-template for more information

using CTMS.Controller;
using CTMS.Services;



int choice = 0;
while (choice!=14)
{
    Console.WriteLine("Enter 1 for Add Employee");
    Console.WriteLine("Enter 2 for Add Department");
    Console.WriteLine("Enter 3 for Add Training Program");
    Console.WriteLine("Enter 4 Update Employee Salary");
    Console.WriteLine("Enter 5 For Enrolle Employee To Training Program");
    Console.WriteLine("Enter 6 for Update The Score Of Enrolled Employee");
    Console.WriteLine("Enter 7 for Delete Training Program");
    Console.WriteLine("Enter 8 for See the TrainingDepartment Details");
    Console.WriteLine("Enter 9 for See the Department Statestics");
    Console.WriteLine("Enter 10 for Delete Department");
    Console.WriteLine("Enter 11 for See the Employees");
    Console.WriteLine("Enter 12 for Delete Employee");
    Console.WriteLine("Enter 13 for see the Training Program");
   GeneralService.FetchUserInputGeneric(ref choice, " Enter The Choice");
    switch (choice)
    {
        case 1:
            {
               EmployeeController.AddEmployeeController(); 
                break; 
            }
        case 2:
            {
               DepartmentController.AddDepartmentController(); 
                break;
            }
        case 3:
            {
               TrainingProgramController.AddTrainingProgramController(); 
                break;
            }
        case 4:
            {
                EmployeeController.UpdateEmployeeSalaryContoller(); 
                break;
            }
        case 5:
            {
               EnrolledEmployeeContoller.EnrollEmployeeToTrainingProgramController();  
                break;
            }
        case 6:
            {
                EnrolledEmployeeContoller.UpdateTheScoreOfEnrolledEmployeeController(); 
                break;
            }
        case 7: 
            {
                TrainingProgramController.DeleteTrainingProgramController();  
                break;
            }
        case 8:
            {
               DepartmentController.ShowTrainingDepartmentDetailsController(); 
                break;
            }
        case 9: 
            {
              DepartmentController.ShowDepartmentStatesticController(); 
                break;
            }
        case 10:
            {
                DepartmentController.DeleteDepartmentController(); 
                break;
            }
        case 11:
            {
                EmployeeController.ShowEmployeesController(); 
                break;
            }
        case 12:
            {
                EmployeeController.DeleteEmployeeContoller();
                break;
            }
        case 13:
            {
               TrainingProgramController.ShowTrainingProgramController();
                break;
            }
        case 14:
            {
                Console.WriteLine("Thankyou for Review..");
                break;
            }
        default:
            {
                Console.WriteLine("Enter Valid Choice..");
                break;
            }
    }
}