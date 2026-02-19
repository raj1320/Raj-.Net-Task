using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFCoreDay1.Repository;
using EFCoreDay1.Services;

namespace EFCoreDay1.Controller
{
    public  class StudentController
    {

        public static void AddStudentController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                StudentRepository studentRepository = new StudentRepository(appDbContext);
                Student newStudent = StudentServices.FetchInputForAddStudent();
                studentRepository.AddStudent(newStudent);
                if (newStudent != null)
                    Console.WriteLine("\nStudent Added Successfully...\n");
                else
                    Console.WriteLine("\nOperation Failed , Try again..\n");
            }

        }

        public static void  ShowStudentsController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                StudentRepository studentRepository = new StudentRepository(appDbContext);
                List<Student> ListOfStudent = studentRepository.GetALLStudents();
                if (ListOfStudent.Count == 0)
                {
                    Console.WriteLine("Empty Record");
                    return;
                }
                foreach (var item in ListOfStudent)
                {
                    Console.WriteLine($" Name = {item.Name} Email = {item.Email}  CreatedAt={item.Created}\n");
                }
            }

         }

        public static void  EnrolledStudentController() 
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                StudentRepository studentRepository = new StudentRepository(appDbContext);
                Student ? CurrentStudent = StudentServices.FetchStudent(studentRepository.GetALLStudents());
               
                if (CurrentStudent==null) { Console.WriteLine("No student Found"); return; }

                CourseRepository courseRepository = new CourseRepository(appDbContext);
                List<Course> listOfCourses = courseRepository.GetALLCourses().ToList();

                StudentServices.FetchAndValidateInputForCourseListFromEnrolledStudent(listOfCourses.ToArray(), CurrentStudent);

                StudentServices.AddStudentInStudentListOfCourse(CurrentStudent);

                appDbContext.SaveChanges();
            }
        }

        public static void UpdateStudentController()
        {
            using(AppDbContext appDbContext = new AppDbContext())
{
                StudentRepository studentRepository = new StudentRepository(appDbContext);
                int ID = 0;
                string? Email = "test123@gmail.com";
                string? Name = "Test";
                StudentServices.ShowStudents(studentRepository.GetALLStudents());
                StudentServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired Student Id");
                if (ID > 0 && ID <= studentRepository.GetALLStudents().Max(x => x.Id))
                {
                    int choice = 0;
                    StudentServices.ForMemoryAllocation_Validation(ref choice, "\n Enter 1 for Update Name \n Enter 2 for Upadte Email");
                    switch (choice)
                    {
                        case 1:
                            {
                                StudentServices.ForMemoryAllocation_Validation(ref Name, "Enter The Name of the Student ");
                                studentRepository.UpdateStudentName(ID, Name);
                                break;
                            }
                        case 2:
                            {
                                StudentServices.ForMemoryAllocation_Validation(ref Email, "Enter The Email of the Student");
                                studentRepository.UpdateStudentEmail(ID, Email ?? "test123@gmail.com");
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

        public static void DeleteStudentController()
        {
            using (AppDbContext appContext = new AppDbContext())
            {
                StudentRepository studentRepository = new StudentRepository(appContext);
                StudentServices.ShowStudents(studentRepository.GetALLStudents());
                int ID = 0;
                StudentServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired Student Id");
                if (ID > 0 && ID <= studentRepository.GetALLStudents().Max(x => x.Id))
                {
                    studentRepository.Delete(ID);
                }
                else
                {
                    Console.WriteLine("Enter Valid Id Try agian...");
                }
            }
        }
    }
}




