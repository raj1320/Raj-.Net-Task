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
            _Context.SaveChanges();
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
    }
}
