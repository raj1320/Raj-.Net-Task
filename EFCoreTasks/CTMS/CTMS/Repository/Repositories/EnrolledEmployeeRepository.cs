using CTMS.Repository.Data;
using CTMS.Repository.Entities;
using Microsoft.EntityFrameworkCore;


namespace CTMS.Repository.Repositories
{
    public class EnrolledEmployeeRepository
    {
        public AppDbContext _Context { get; set; }
        public EnrolledEmployeeRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        public void AddEnrolledEmployee(EnrolledEmployee enrolledEmployee)
        {
                _Context.EnrolledEmployees.Add(enrolledEmployee);
                _Context.SaveChanges();
                Console.WriteLine("Employee Enrolled Successfully..."); 
        }

        public EnrolledEmployee? GetEnrolledEmployee(int Id)
        {
            var enrolledEmployee = _Context.EnrolledEmployees.Include(x => x.Employee).FirstOrDefault(x => x.Id == Id);
            return enrolledEmployee;
        }

        public List<EnrolledEmployee> GetAllEnrolledEmployee()
        {
            var listOfEnrolledEmployee = _Context.EnrolledEmployees.Include(x => x.Employee).Include(x=>x.TrainingPrograms).ToList();
            return listOfEnrolledEmployee;
        }
        
        public void AddTrainingProgrm(int Id,TrainingProgram trainingProgram)
        {
            var enrolledEmployee = GetEnrolledEmployee(Id);
            if (enrolledEmployee != null)
            {
                enrolledEmployee.TrainingPrograms.Add(trainingProgram);
               _Context.SaveChanges();
            }
        }
        
        public void UpdateEnrolledEmployeeScore(int Id ,int Score)
        {
            var enrolledEmployee = _Context.EnrolledEmployees.FirstOrDefault(x => x.Id == Id);
            if (enrolledEmployee != null)
            {
                enrolledEmployee.Score = Score;
                _Context.SaveChanges();
                Console.WriteLine("Score Updated Successfully..");
            }
            else
            {
                Console.WriteLine("No Record Found..");
            }
                
        }
        
        public void DeleteEnrolledEmployee(int Id)
        {
            var enrolledEmployee = _Context.EnrolledEmployees.FirstOrDefault(x=>x.Id==Id);
            if (enrolledEmployee != null)
            {
                _Context.EnrolledEmployees.Remove(enrolledEmployee);
                _Context.SaveChanges();
                Console.WriteLine("Employee is Remove Successfully");
            }
            else Console.WriteLine("Record Not Found...");
        }


    }
}
