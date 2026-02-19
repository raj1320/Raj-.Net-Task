
using EFCoreDay1.Entities;
using System.Text.RegularExpressions;

namespace EFCoreDay1.Services
{
    public class StudentServices
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

        public static Student FetchInputForAddStudent()
        {
            Student student = new Student();
            Console.WriteLine("Enter Student Name");
            student.Name = Console.ReadLine() ?? "TestUser";

            Console.WriteLine("Enter Student Email");
            string Email = Console.ReadLine() ?? "test123@gmail.com";


            Console.WriteLine();

            Regex emailValidatore = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");

            while (!emailValidatore.IsMatch(Email))
            {
                Console.WriteLine("Enter valid Format of Email..");
                Email = Console.ReadLine() ?? "test123@gmail.com";
                Console.WriteLine();
            }

            student.Email = Email;

            student.Created = DateTime.Now;

            return student;
        }

        public static Student? FetchStudent(List<Student> listOfStudents)
        {
            Student? student = new Student();
            if (listOfStudents.Count() > 0)
            {
                int Id = 0;
                while (true)
                {
                    foreach (var std in listOfStudents)
                    {
                        Console.WriteLine($"Name of the Student is : {std.Name} and Id is :{std.Id}");
                    }
                    ForMemoryAllocation_Validation(ref Id, "\nEnter id of Student for Enrolling him/her to the course..\n");
                    if (Id > 0 && Id <= listOfStudents.Max(x => x.Id))
                    {
                        student = listOfStudents.Where(x => x.Id == Id).FirstOrDefault();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Id is invalid");
                    }
                }
            }
            return student;
        }

        public static void FetchAndValidateInputForCourseListFromEnrolledStudent(Course[] listOfCourses, Student student)
        {
            int flag = 0;
            while (flag == 0)
            {
                Console.WriteLine("\nSelect 1,2.. accordingly for Enrolling student into desired course (please write 1,2,3 this format)");
                Console.WriteLine("\nList Of Course--->");
                Console.WriteLine("============================");
                foreach (Course course in listOfCourses)
                {
                    Console.WriteLine("Course Title is : " + course.Title);
                }
                Console.WriteLine("============================");
                var inputlist = Console.ReadLine();
                string[]? list = inputlist?.Trim().Split(',');
                if (list == null && list?.Length == 0)
                {
                    Console.WriteLine("\nInput is not acceptable\n");
                }
                else
                {

                    int i = 0;
                    while (i < list?.Length)
                    {
                        int idx = 0;
                        idx = int.Parse(list[i]);
                        Console.WriteLine("\n============================================");
                        if (idx > 0 && idx <= listOfCourses.Count())
                        {
                            int idxmain = idx - 1;
                            student.Courses.Add(listOfCourses[idxmain]);
                            Console.WriteLine(idxmain + 1 + " course is " + listOfCourses[idxmain].Title + " Course Enrolled Succsessfully..");
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Enter valid choice");
                            flag = 1;
                            break;
                        }
                        Console.WriteLine("============================================\n");

                    }
                    if (flag == 0) break;
                }

            }
        }

        public static void AddStudentInStudentListOfCourse(Student student)
        {
             var list_Of_Course_In_which_Studentnrolled = student.Courses;
             foreach (var item in list_Of_Course_In_which_Studentnrolled)
             {
                    item.Students.Add(student);
             }
        }
    
        public static void ShowStudents(List<Student> listOfStudents)
        {
            foreach (var std in listOfStudents)
            {
                Console.WriteLine($"Name of the Student is : {std.Name} and Id is :{std.Id}");
            }
        }
    


    }

}
