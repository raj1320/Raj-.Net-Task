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
            enrolledEmployee.Employee.IsEnrolled = true;
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
        
         
        public void UpdateEnrolledEmployeeScore(int TPID,int ENID,int Score)
        {



            var enrolledemp= GetEnrolledEmployee(ENID);
            if (enrolledemp!=null)
            {
               Score?score=  _Context.Scores.SingleOrDefault(x=>x.TrainingProgramId==TPID && x.EnrolledEmployeeId==ENID);
                if (score != null)
                {
                    score.ScoreValue = Score < 100 && Score >=0 ? Score : score.ScoreValue;
                    _Context.SaveChanges();
                    Console.WriteLine("Score Updated Successfully...");
                    return;
                }
            }

            Console.WriteLine("No Update...");
       
                
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
