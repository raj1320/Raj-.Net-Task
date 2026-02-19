using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFCoreDay1.Repository;
using EFCoreDay1.Services;
using EFWithRelationships.Data;


namespace EFCoreDay1.Controller
{
    public class BatchController
    {
        public static void CreateBatchController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                BatchRepository batchRepository = new BatchRepository(appDbContext);
                CourseRepository courseRepository = new CourseRepository(appDbContext);
                TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
                Batch newBatch = BatchServices.FetchInputForCreateBatch(trainerRepository.GetALLTrainers().ToList(), courseRepository.GetALLCourses().ToList());
                Trainer? trainer = trainerRepository.GetTrainer(newBatch.TrainerId);
                Course? course = courseRepository.GetCourse(newBatch.CourseId);

                trainer?.Batches.Add(newBatch);
                course?.Batches.Add(newBatch);

                appDbContext.SaveChanges();
                if (newBatch != null)
                    Console.WriteLine("\nBatch Created Successfully...\n");
                else
                    Console.WriteLine("\nOperation Failed , Try again..\n");
            }
        }
    }
}
