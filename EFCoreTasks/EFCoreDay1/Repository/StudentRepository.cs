using EFCoreDay1.Data;
using EFCoreDay1.Entities;


namespace EFCoreDay1.Repository
{
    public class StudentRepository
    {
        public AppDbContext _Context;
        public StudentRepository(AppDbContext context)
        {
            _Context = context;
        }
        public Student AddStudent(Student student)
        {
            _Context.Students.Add(student);
            Console.WriteLine("Student Entity Before Save Change :"+_Context.Entry(student).State);
            _Context.SaveChanges();
            Console.WriteLine("Student Entity After Save Change :" +_Context.Entry(student).State);
            return student;
        }
    
        public List<Student> GetALLStudents()
        {
            var students = _Context.Students;
            return students.ToList();
         }

        public Student? UpdateStudentEmail(int Id,string Email) 
        {
            var student = _Context.Students.FirstOrDefault(x => x.Id == Id);
            if (student != null)
            {

                student.Email =Email == "test123@gmail.com" ? student.Email : student.Email;
                Console.WriteLine("Student Entity Before Save Change :" + _Context.Entry(student).State);
                _Context.SaveChanges();
                Console.WriteLine("Student Entity After Save Change :" + _Context.Entry(student).State);
                Console.WriteLine("Email Updated successfully..");
                return student;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }

        }

        public Student? UpdateStudentName(int Id, string?Name)
        {

            var student =  _Context.Students.FirstOrDefault(x => x.Id == Id);
            if (student != null) 
            {

                student.Name = Name ?? student.Name;
                Console.WriteLine("Student Entity Before Save Change :" + _Context.Entry(student).State);
                _Context.SaveChanges();
                Console.WriteLine("Student Entity After Save Change :" + _Context.Entry(student).State);
                Console.WriteLine("Name Updated successfully..");
                return student;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }

        }

        public bool Delete(int Id)
        {
            var student = _Context.Students.FirstOrDefault(x => x.Id == Id);

            if (student != null)
            {
                _Context.Students.Remove(student);
                Console.WriteLine("Student Entity Before Save Change :" + _Context.Entry(student).State);
                _Context.SaveChanges();
                Console.WriteLine("Student Entity After Save Change :" + _Context.Entry(student).State);
                Console.WriteLine("Deleted Successfully..");
                return true;
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return false;
            }

        }
    }
}
