
using EFCoreDay1.Data;
using EFWithRelationships.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDay1.Repository
{
    public class BatchRepository
    {
        public AppDbContext _context;
        public BatchRepository(AppDbContext appDbContext)
        {
            this._context= appDbContext;
        }

        public Batch AddBatch(Batch batch)
        {
            _context.Batches.Add(batch);
            _context.SaveChanges();
            return batch;
        }
        public List<Batch> ShowBatches()
        {
            var listOfBatch = _context.Batches.Include(x => x.Trainer).Include(x => x.Course).ToList();
                                          
            return listOfBatch;
        }
    }
}
