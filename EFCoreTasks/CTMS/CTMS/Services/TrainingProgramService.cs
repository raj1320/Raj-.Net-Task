
using CTMS.Repository.Entities;
using CTMS.Services;

namespace CTMS.Services
{
    public class TrainingProgramService
    {
        public static TrainingProgram? FetchInputForTrainingProgramService(List<TrainingProgram> trainingPrograms)
        {
            TrainingProgram trainingProgram = new TrainingProgram();
            Console.WriteLine("Enter the Title of the Training Program : ");
            string Title = Console.ReadLine() ?? "Test";
            foreach (var item in trainingPrograms)
            {
                if (item.Title == Title)
                {
                    Console.WriteLine("Program already present...");
                    return null;
                }
            }
            int Duration = 0;
            GeneralService.FetchUserInputGeneric(ref Duration, "Enter the Duration for the Program : ");

            int Day = 0;
            GeneralService.FetchUserInputGeneric(ref Day, "Enter the Day of Month for Start Date : ");
            int Month = 0;
            GeneralService.FetchUserInputGeneric(ref Month, "Enter the Month for Start Date : ");
            int Year = 0;
            GeneralService.FetchUserInputGeneric(ref Year, "Enter the Year for Start Date : ");

            trainingProgram.Title = Title;
            trainingProgram.DurationInDays = Duration;
            trainingProgram.StartDate = new DateTime(Year, Month, Day);

            return trainingProgram;
        }

        public static void ShowTrainingProgramsless(List<TrainingProgram> trainingPrograms)
        {
            Console.Write("\nHere is the list of Training Program\n");
            Console.WriteLine("========================================================================");
            foreach (var item in trainingPrograms)
            {
                Console.WriteLine($"Training Program Id : {item.Id} Program Title : {item.Title} , Program Start Date : {item.StartDate}");
               
            }
            Console.WriteLine("========================================================================");

        }

        public static void ShowTrainingPrograms(List<TrainingProgram> trainingPrograms)
        {
            Console.Write("\nHere is the list of Training Program\n");
            Console.WriteLine("========================================================================\n");
            foreach (var item in trainingPrograms)
            {
                Console.WriteLine($"Training Program Id : {item.Id} Program Title : {item.Title} , Program Start Date : {item.StartDate}");
                Console.WriteLine("========================================================================");
                foreach (var Trainer in item.TrainerEmployees)
                {
                    Console.WriteLine($"Trainer Name : {Trainer.Employee.Name} , Trainer Year Of Experience : {Trainer.Employee.YearsOfExperties}");
                }
                Console.WriteLine("========================================================================");
            }
        }

        public static int FetchInputTrainingProgramIdService(List<TrainingProgram> trainingPrograms)
        {

            int Id = 0;
            while (true)
            {
                ShowTrainingProgramsless(trainingPrograms);

                GeneralService.FetchUserInputGeneric(ref Id, "Enter The Id Of Training Program");
                
                if(trainingPrograms.Count() == 0)  return Id;

                foreach (var item in trainingPrograms)
                {
                    if (item.Id == Id)
                    {
                        return Id;
                    }
                }

            }
        }
    }
}