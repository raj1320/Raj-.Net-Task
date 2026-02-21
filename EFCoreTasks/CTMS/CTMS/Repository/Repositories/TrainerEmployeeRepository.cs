
using CTMS.Repository.Data;
using CTMS.Repository.Entities;

using Microsoft.EntityFrameworkCore;
namespace CTMS.Repository.Repositories
{
    public class TrainerEmployeeRepository
    {
        AppDbContext _Context;
        public TrainerEmployeeRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }

        public void AddTrainerEmployee(TrainerEmployee trainerEmployee)
        {
            _Context.TrainerEmployees.Add(trainerEmployee);

        }

        public TrainerEmployee? GetTrainerEmployee(int Id)
        {
            var trainerEmployee = _Context.TrainerEmployees.Include(x=>x.Employee).FirstOrDefault(x => x.Id == Id);
            return trainerEmployee;
        }

        public List<TrainerEmployee> GetAllTrainerEmployee()
        {
            var ListOfTrainerEmployee = _Context.TrainerEmployees.Include(x => x.Employee).ToList();
            return ListOfTrainerEmployee;
        }

        public void DeleteTrainerEmployee(int Id)
        {
            var trainerEmployee = _Context.TrainerEmployees.FirstOrDefault(x => x.Id == Id);
            if (trainerEmployee != null)
            {
                _Context.TrainerEmployees.Remove(trainerEmployee);
                _Context.SaveChanges();
                Console.WriteLine("TrainerEmployee is Remove From the Training Program");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }
    }
}
