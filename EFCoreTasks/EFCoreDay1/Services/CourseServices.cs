
using EFCoreDay1.Data;
using EFCoreDay1.Entities;

namespace EFCoreDay1.Services
{
    public class CourseServices
    {
        public static void ForMemoryAllocation_Validation<T>(ref T? Num, string msg) where T : IParsable<T>
        {
            while (true)
            {
                string? userInput;
                Console.WriteLine($"{msg} ");
                userInput = Console.ReadLine();
                if (T.TryParse(userInput, null, out Num))
                    break;
                Console.WriteLine("Provide appropriate input");
            }
        }

        public static Course FetchInputForAddCourse()
        {
            Course course = new Course();
            Console.WriteLine("Enter Course Title: ");
            course.Title = Console.ReadLine() ?? "TestCourse";

            double Fees = 1500;
            ForMemoryAllocation_Validation(ref Fees, "Enter Fees for Course: ");
            if (Fees > 0) course.Fees = Fees;
            else course.Fees = 1500;

            int DurationInMonths = 6;
            ForMemoryAllocation_Validation(ref DurationInMonths, "Enter Duration In Months: ");
            if (DurationInMonths > 0) course.DurationInMonths = DurationInMonths;
            else course.DurationInMonths = 6;

            return course;
        }
 
        public static int FetchInputForGettingCourseId(List<Course> courses)
        {
            int Id = 1;
            Console.WriteLine("List of Available course...");
            Console.WriteLine("============================================");
            foreach (Course course in courses)
            {
                Console.WriteLine($"Course Title : {course.Title} , Course Id : {course.Id}");
            }
            Console.WriteLine("============================================");
            ForMemoryAllocation_Validation(ref Id, "Enter Id");
            return Id;

        }

        public static void PrintCourse(Course course)
        {
            Console.WriteLine("Course Ttitle is : " + course.Title);
            Console.WriteLine("Course Fees is : " + course.Fees);
            Console.WriteLine("Course Duration in Months is : " + course.DurationInMonths);
            Console.WriteLine("============================================");
            foreach (var item in course.Students)
            {
                Console.WriteLine($"Student Name is : {item.Name} and Student Email is : {item.Email}");
            }
            foreach (var item in course.Batches)
            {
                Console.WriteLine($"Batch StartDate is : {item.Id}  Batch id is : {item.Id}");
            }
            Console.WriteLine("============================================");

        }

        public static void ShowCourses(List<Course> ListOfcourse)
        {
            foreach (var course in ListOfcourse)
            {
                Console.WriteLine($"Name of the Course is : {course.Title} and Id is :{course.Id}");
            }
        }

        public static void ShowCoursesByExplisitLoading(List<Course> ListOfCourse,AppDbContext appDbContext)
        {
            int Id = FetchInputForGettingCourseId(ListOfCourse);
            foreach (var item in ListOfCourse)
            {
                Console.WriteLine($" Title = {item.Title} Fees = {item.Fees}  Duration In Months ={item.DurationInMonths}\n");
                if (item.Id == Id)
                {
                    appDbContext.Entry(item).Collection(x => x.Students);
                    Console.WriteLine($" Here students are printed for this course only, yet you choose this course\n {item.Title} students are :- ");
                    Console.WriteLine("=========================");
                    foreach (var student in item.Students)
                    {
                        Console.WriteLine("\t"+student.Name+"\n");
                    }
                    Console.WriteLine("=========================");


                }
            }
        }
   
    }
}
