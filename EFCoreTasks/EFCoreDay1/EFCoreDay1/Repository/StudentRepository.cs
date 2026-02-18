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
            _Context.SaveChanges();
            return student;
        }
    
        public List<Student> GetALLStudents()
        {
            var students = _Context.Students;
            return students.ToList();
         }
    }
}
