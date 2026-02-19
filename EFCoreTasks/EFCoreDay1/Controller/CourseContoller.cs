using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFCoreDay1.Repository;
using EFCoreDay1.Services;


namespace EFCoreDay1.Controller
{
    public class CourseContoller
    {
        public static void AddCouseController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                CourseRepository courseRepository = new CourseRepository(appDbContext);
                Course newCourse = CourseServices.FetchInputForAddCourse();
                courseRepository.AddCourse(newCourse);
                if (newCourse != null)
                    Console.WriteLine("\nCourse Added Successfully...\n");
                else
                    Console.WriteLine("\nOperation Failed , Try again..\n");
            }
        }

        public static void ShowCourseController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {

                CourseRepository courseRepository = new CourseRepository(appDbContext);
                List<Course> ListOfCourse = courseRepository.GetALLCourses();
                if (ListOfCourse.Count == 0)
                {
                    Console.WriteLine("Empty Record");
                    return;
                }
                foreach (var item in ListOfCourse)
                {
                    Console.WriteLine($" Title = {item.Title} Fees = {item.Fees}  Duration In Months ={item.DurationInMonths}\n");
                }

            }
        }

        public static void ShowCourseWithStudentController()
        {

            using (AppDbContext appDbContext = new AppDbContext())
            {
                CourseRepository courseRepository = new CourseRepository(appDbContext);
                List<Course> courses = courseRepository.GetALLCourses();
                int courseId = CourseServices.FetchInputForGettingCourseId(courses.ToList());
                Course? course = courseRepository.GetCourse(courseId);
                if (course != null)
                    CourseServices.PrintCourse(course);
                else
                    Console.WriteLine("\nCourse Is Not Found\n");
            }
        }

        public static void UpdateCourseController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                CourseRepository courseRepository = new CourseRepository(appDbContext);
                int ID = 0;
                string? Title = "Test";
                double Fees = 10000;
                int DurationMonths = 6;
                CourseServices.ShowCourses(courseRepository.GetALLCourses());
                CourseServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired CourseId");

                if (ID > 0 && ID <= courseRepository.GetALLCourses().Max(x => x.Id))
                {
                    int choice = 0;
                    CourseServices.ForMemoryAllocation_Validation(ref choice, "\n Enter 1 for Update Title \n Enter 2 for Upadte Fees \n Enter 3 for Update DurationMonths");

                    switch (choice)
                    {
                        case 1:
                            {
                                CourseServices.ForMemoryAllocation_Validation(ref Title, "Enter The Title of the Course ");
                                courseRepository.UpdateCourseTitle(ID, Title ?? "Test");
                                break;
                            }
                        case 2:
                            {
                                CourseServices.ForMemoryAllocation_Validation(ref Fees, "Enter The Fees of the Course");
                                courseRepository.UpdateCourseFees(ID, Fees);
                                break;
                            }
                        case 3:
                            {
                                CourseServices.ForMemoryAllocation_Validation(ref DurationMonths, "Enter The DurationMonths of the Course");
                                courseRepository.UpdateCourseFees(ID, DurationMonths);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Enter The Valid Case");
                                break;
                            }
                    }

                }
                else
                {
                    Console.WriteLine("Enter Valid Id Try agian...");
                }


            }
        }

        public static void DeleteCourseController()
        {
            using (AppDbContext appContext = new AppDbContext())
            {
                CourseRepository courseRepository = new CourseRepository(appContext);
                CourseServices.ShowCourses(courseRepository.GetALLCourses());
                int ID = 0;
                CourseServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired Course Id");
                if (ID > 0 && ID <= courseRepository.GetALLCourses().Max(x => x.Id))
                {
                    courseRepository.Delete(ID);
                }
                else
                {
                    Console.WriteLine("Enter Valid Id Try agian...");
                }
            }
        }

        public static void ChooseAndSeeTheCourseStudentListByExplisitCastingController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {

                CourseRepository courseRepository = new CourseRepository(appDbContext);
                List<Course> ListOfCourse = courseRepository.GetALLCourses();

                CourseServices.ShowCoursesByExplisitLoading(ListOfCourse, appDbContext);
                
            }
        }
    }
}
