using EFWithRelationships.Data;


namespace EFCoreDay1.Services
{
    public class TrainerServices
    {
        public static void ForMemoryAllocation_Validation<T>(ref T? Num, string msg) where T : IParsable<T>
        {
            while (true)
            {
                string? userInput;
                Console.WriteLine($"{msg} ");
                userInput = Console.ReadLine();
                if (T.TryParse(userInput, null, out Num))
                    break;
                Console.WriteLine("Provide appropriate input");
            }
        }
        public static void ShowTrainer(List<Trainer> ListOftrainer) 
        {
            foreach (var Trainer in ListOftrainer)
            {
                Console.WriteLine($"Name of the Course is : {Trainer.Name} and Id is :{Trainer.Id}");
            }
        }
     
        public static Trainer FetchInputForAddTrainer()
        {
            Trainer trainer = new Trainer();
            Console.WriteLine("Enter Trainer Name");
            trainer.Name = Console.ReadLine() ?? "TestTrainer";
            trainer.Name.Trim();

            int ExperienceYears = 5;
            ForMemoryAllocation_Validation(ref ExperienceYears, "Enter Trainer ExperienceYears");
            if (ExperienceYears > 0)
            {
                trainer.ExperienceYears = ExperienceYears;
            }
            else
            {
                trainer.ExperienceYears = 1;
            }
            return trainer;
        }

        public static int FetchInputForGettingTrainerId(List<Trainer> trainers) 
        {
            int Id = 1;
            Console.WriteLine("============================================");
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine($"Trainer Name :{trainer.Name} , Trainer Id : {trainer.Id}");
            }
            Console.WriteLine("============================================");
            ForMemoryAllocation_Validation(ref Id, "Enter Id");
            return Id;
        }

        public static void  PrintTrainer(Trainer trainer)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("Trainer Name is :" + trainer.Name);
            Console.WriteLine("Year of Experience is :" + trainer.ExperienceYears);
            if (trainer.Batches.Count() == 0) { Console.WriteLine("No Records Found"); }
            foreach (var item in trainer.Batches)
            {
                Console.WriteLine($"Batch start Date is : {item.StartDate}");
                Console.WriteLine($"Course Id is : {item.Course.Title}");
                Console.WriteLine($"Course Fees is : {item.Course.Fees}");
                Console.WriteLine($"Course Months is : {item.Course.DurationInMonths}");
            }
            Console.WriteLine("==========================================================");

        }

        public static void ShowTrainerWithLazyloading(List<Trainer> listOfTrainer)
        {
            foreach (var trainer in listOfTrainer)
            {
                var Batch = trainer.Batches.ToList();

                Console.WriteLine($"Trainer name is : {trainer.Name}\n");
                int i = 1;
                foreach (var batch in Batch)
                {
                    Console.WriteLine($" Batch {i++} is start from: {batch.StartDate}");
                }
                Console.WriteLine();
            }
        }
    
    }
}
