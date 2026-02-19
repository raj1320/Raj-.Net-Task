using EFCoreDay1.Data;
using EFCoreDay1.Repository;
using EFCoreDay1.Services;
using EFWithRelationships.Data;


namespace EFCoreDay1.Controller
{
    public class TrainerContoller
    {
        public static void AddTrainerController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
                Trainer newTrainer = TrainerServices.FetchInputForAddTrainer();
                trainerRepository.AddTrainer(newTrainer);
                if (newTrainer != null)
                    Console.WriteLine("\nTrainer Added Successfully...\n");
                else
                    Console.WriteLine("\nOperation Failed , Try again..\n");
            }
        }

        // Here i am performing eager loading which load the entire data from the  Sql server using Include ..
        public static void ShowTrainerWithBatchesController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
                // Here i am performing eager loading which load the entire data from the  Sql server using Include ..
                List<Trainer> trainers = trainerRepository.GetALLTrainers();
                int trainerId = TrainerServices.FetchInputForGettingTrainerId(trainers.ToList());
                Trainer? trainer = trainerRepository.GetTrainer(trainerId);
                if (trainer != null)
                   TrainerServices.PrintTrainer(trainer);
                else
                    Console.WriteLine("\nTrainer Is Not Found\n");
            }
        }

        public static void  UpdateTrainerController()
        {
            using (AppDbContext appDbContext = new AppDbContext())
            {
                TrainerRepository trainerRepository = new TrainerRepository(appDbContext);
                int ID = 0;
                string?Name = "Test";
                int Experience = 0;
                TrainerServices.ShowTrainer(trainerRepository.GetALLTrainers());
                TrainerServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired Trainer Id");

                if (ID > 0 && ID <= trainerRepository.GetALLTrainers().Max(x => x.Id))
                {
                    int choice = 0;
                    TrainerServices.ForMemoryAllocation_Validation(ref choice, "\n Enter 1 for Update Trainer Name \n Enter 2 for Upadte Trainer Experience");
                    switch (choice)
                    {
                        case 1:
                            {
                                TrainerServices.ForMemoryAllocation_Validation(ref Name, "Enter The Name of the Trainer ");
                                trainerRepository.UpdateTrainerName(ID, Name ?? "Test");
                                break;
                            }
                        case 2:
                            {
                                TrainerServices.ForMemoryAllocation_Validation(ref Experience, "Enter The Experience of the Trainer");
                                trainerRepository.UpdateTrainerExperienceYears(ID, Experience);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Enter The Valid Case");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid Id Try agian...");
                }


            }
        }

        public static void DeleteTrainerController()
        {
            using (AppDbContext appContext = new AppDbContext())
            {
                TrainerRepository trainerRepository = new TrainerRepository(appContext);
                TrainerServices.ShowTrainer(trainerRepository.GetALLTrainers());
                int ID = 0;
                TrainerServices.ForMemoryAllocation_Validation(ref ID, "Enter The Desired Trainer Id");
                if (ID > 0 && ID <= trainerRepository.GetALLTrainers().Max(x => x.Id))
                {
                    trainerRepository.Delete(ID);
                }
                else
                {
                    Console.WriteLine("Enter Valid Id Try agian...");
                }
            }
        }

        // Here i am performing lazy loading which fires N+1 queries for fatching Batch data from trainer 
        public static void ShowTrainersDatawithLazyLoadingController()
        {
            using (AppDbContext appDbContext = new AppDbContext()) 
            {
                var listOfTrainer = appDbContext.Trainers.ToList();
                TrainerServices.ShowTrainerWithLazyloading(listOfTrainer);
            }
        }
    }
}
