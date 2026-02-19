using EFCoreDay1.Controller;
using EFCoreDay1.Data;
static void ForMemoryAllocation_Validation<T>(ref T? Num, string msg) where T : IParsable<T>
{
    while (true)
    {
        string? userInput;
        Console.WriteLine($"{msg} ");
        userInput = Console.ReadLine();
        if (T.TryParse(userInput, null, out Num))
            break;
        Console.WriteLine("\nProvide appropriate input");
    }
}


int value = 1;

while (value != 19)
{
    Console.WriteLine("\nEnter 1 for Add New Student");
    Console.WriteLine("Enter 2 for Add New Course");
    Console.WriteLine("Enter 3 for Show All Students ");
    Console.WriteLine("Enter 4 for show All Courses");
    Console.WriteLine("Enter 5 for Enrolle Student");
    Console.WriteLine("Enter 6 for Add Trainer");
    Console.WriteLine("Enter 7 for Create Batch");
    Console.WriteLine("Enter 8 for show Course with Students");
    Console.WriteLine("Enter 9 for show Trainer with Batches");
    Console.WriteLine("Enter 10 for Update Student");
    Console.WriteLine("Enter 11 for Update Course");
    Console.WriteLine("Enter 12 for Update Trainer");
    Console.WriteLine("Enter 13 for Delete Student");
    Console.WriteLine("Enter 14 for Delete Course");
    Console.WriteLine("Enter 15 for Delete Trainer");
    Console.WriteLine("Enter 16 for Add Club and Check AsNoTracking behaviour");
    Console.WriteLine("Enter 17 for Show Trainer with Lazy loading..");
    Console.WriteLine("Enter 18 for Show Courses via Explisit Casting");
    Console.WriteLine("Enter 19 for Exite");
    ForMemoryAllocation_Validation(ref value, "Enter choice");
    switch (value)
    {
        case 1:
            {
               StudentController.AddStudentController();
                break;
            }
        case 2:
            {
               CourseContoller.AddCouseController();
                break;
            }
        case 3:
            {
                StudentController.ShowStudentsController();
                break;
            }
        case 4:
            {
                CourseContoller.ShowCourseController();
                break;
            }
        case 5:
            {

                StudentController.EnrolledStudentController();
                break;
            }
        case 6:
            {
                TrainerContoller.AddTrainerController();
                break;
            }
        case 7:
            {
                BatchController.CreateBatchController();
                break;
            }
        case 8:
            {
                CourseContoller.ShowCourseWithStudentController();
                break;
            }
        case 9:
            {
               TrainerContoller.ShowTrainerWithBatchesController();
                break;
            }
        case 10:
            {
                StudentController.UpdateStudentController();
                break;
            }
        case 11:
            {
                CourseContoller.UpdateCourseController();
                break;
            }
        case 12:
            {
               TrainerContoller.UpdateTrainerController();
                break;
            }
        case 13:
            {
                StudentController.DeleteStudentController();
                break;
            }
        case 14:
            {
                CourseContoller.DeleteCourseController();
                break;
            }
        case 15:
            {
                TrainerContoller.DeleteTrainerController();
                break;
            }
        case 16:
            {
                ClubClassesController.AddClubsController();
                break;
            }
        case 17:
            {
               
                AppDbContext.EnableLazyLoadingLogging=true;
                TrainerContoller.ShowTrainersDatawithLazyLoadingController();
                AppDbContext.EnableLazyLoadingLogging=false;
                break;
            }
        case 18:
            {
                CourseContoller.ChooseAndSeeTheCourseStudentListByExplisitCastingController();
                break;
            }
        case 19:
            {
                Console.WriteLine("Thank you for review..");
                break;
            }
        default:
            {
                Console.WriteLine("\nEnter valid choice\n");
                break;
            }
  
    }


    
}




