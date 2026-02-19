using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;


namespace EFCoreDay1.Repository
{
    public class TrainerRepository
    {
        public AppDbContext _Context;
        public TrainerRepository(AppDbContext context)
        {
            _Context = context;
        }
        public Trainer AddTrainer(Trainer trainer)
        {
            _Context.Trainers.Add(trainer);
            Console.WriteLine("Trainer Entity Before Save Change :" + _Context.Entry(trainer).State);
            _Context.SaveChanges();
            Console.WriteLine("Trainer Entity After Save Change :" + _Context.Entry(trainer).State);
            return trainer;
        }

        public Trainer? GetTrainer(int Id)
        {
            var trainerList = _Context.Trainers.Include(t=>t.Batches).ThenInclude(b=>b.Course);
            return trainerList.SingleOrDefault(t=>t.Id==Id);
        }

        public List<Trainer> GetALLTrainers()
        {
            var trainers = _Context.Trainers;
            return trainers.ToList();
        }

        public Trainer? UpdateTrainerName(int Id,string name) 
        {
            var trainer = _Context.Trainers.FirstOrDefault(x => x.Id == Id);

            if (trainer != null)
            {
                trainer.Name = name;
                Console.WriteLine("Trainer Entity Before Save Change :" + _Context.Entry(trainer).State);
                _Context.SaveChanges();
                Console.WriteLine("Trainer Entity After Save Change :" + _Context.Entry(trainer).State);
                Console.WriteLine("Name Updated successfully..");
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }
            return trainer;
        }

        public Trainer? UpdateTrainerExperienceYears(int Id, int ExperienceYears)
        {
            var trainer = _Context.Trainers.FirstOrDefault(x => x.Id == Id);

            if (trainer != null)
            {
                trainer.ExperienceYears = ExperienceYears;
                Console.WriteLine("Trainer Entity Before Save Change :" + _Context.Entry(trainer).State);
                _Context.SaveChanges();
                Console.WriteLine("Trainer Entity After Save Change :" + _Context.Entry(trainer).State);
                Console.WriteLine("ExperienceYears Updated successfully..");
            }
            else
            {
                Console.WriteLine("No Record Found..");
                return null;
            }
                return trainer;
        }

        public bool Delete(int Id)
        { 
             var trainer = _Context.Trainers.FirstOrDefault(x=>x.Id == Id);

            if (trainer != null)
            {
                _Context.Trainers.Remove(trainer);
                Console.WriteLine("Trainer Entity Before Save Change :" + _Context.Entry(trainer).State);
                _Context.SaveChanges();
                Console.WriteLine("Trainer Entity After Save Change :" + _Context.Entry(trainer).State);
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
