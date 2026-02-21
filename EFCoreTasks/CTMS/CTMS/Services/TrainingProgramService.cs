
using CTMS.Repository.Entities;

namespace CTMS.Services
{
    public class TrainingProgramService
    {
        public static TrainingProgram FetchInputForTrainingProgramService()
        {
            TrainingProgram trainingProgram = new TrainingProgram();
            Console.WriteLine("Enter the Title of the Training Program : ");
            string Title = Console.ReadLine() ?? "Test";
            int Duration = 0;
            GeneralService.FetchUserInputGeneric(ref Duration,"Enter the Duration for the Program : ");

            int Day = 0;
            GeneralService.FetchUserInputGeneric(ref Day, "Enter the Day of Month for Start Date : ");
            int Month = 0;
            GeneralService.FetchUserInputGeneric(ref Month, "Enter the Month for Start Date : ");
            int Year = 0;
            GeneralService.FetchUserInputGeneric(ref Year, "Enter the Year for Start Date : ");

            trainingProgram.Title = Title;
            trainingProgram.DurationInDays = Duration;
            trainingProgram.StartDate= new DateTime(Year,Month,Day);

            return trainingProgram;
        }

        public static void ShowTrainingPrograms(List<TrainingProgram> trainingPrograms)
        {
            Console.Write("Here is the list of Training Program");
            foreach (var item in trainingPrograms)
            {
                Console.WriteLine($"Program Title : {item.Title} , Program Start Date : {item.StartDate}");
                foreach (var Trainer in item.TrainerEmployees)
                {
                    Console.WriteLine($" Trainer Name : {Trainer.Employee.Name} , Trainer Year Of Experience : {Trainer.Employee.YearsOfExperties}");
                }
            }
        }
        public static int FetchInputTrainingProgramIdService(List<TrainingProgram> trainingPrograms)
        {

            ShowTrainingPrograms(trainingPrograms);
            int Id = 0;
            GeneralService.FetchUserInputGeneric(ref Id, "Enter The Id Of Training Program");
            if(Id > 0 && Id <= trainingPrograms.Max(x=>x.Id)) 
                return Id;
            else 
                return 0;
                
        }
    }
}
