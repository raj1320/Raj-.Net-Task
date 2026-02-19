using EFCoreDay1.Entities;
using EFWithRelationships.Data;


namespace EFCoreDay1.Services
{
    public class BatchServices
    {
        static void ForMemoryAllocation_Validation<T>(ref T? Num, string msg) where T : IParsable<T>
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
        public static Batch FetchInputForCreateBatch(List<Trainer> listOfTrainer, List<Course> listOfCourse) 
        {


            Batch batch = new Batch();
            int Month = 1;
            int Day = 1;
            int Year = 1;

            ForMemoryAllocation_Validation(ref Month, "Enter Batch start Month");
            ForMemoryAllocation_Validation(ref Day, "Enter Batch start Day of Month");
            ForMemoryAllocation_Validation(ref Year, "Enter Batch start Year");

            DateTime startDate = new DateTime(Year, Month, Day);
            batch.StartDate = startDate;

            int choice = 1;

            int tag = 1;
            while (tag != 0)
            {
                foreach (Trainer trainer in listOfTrainer)
                {
                    Console.WriteLine($"Name of the Trainer is : {trainer.Name}, Experience : {trainer.ExperienceYears}");
                }
                ForMemoryAllocation_Validation(ref choice, "\nEnter 1 or 2 or 3.. for Select a Trainer for Batch..");
                if (choice > 0 && listOfTrainer.Count() >= choice)
                {
                    batch.TrainerId = listOfTrainer.ToArray()[choice - 1].Id;
                    tag = 0;
                }
                else
                {
                    Console.WriteLine("Enter valid choice");
                }

            }
            Console.WriteLine("\n============================================================\n");
            tag = 1;
            while (tag != 0)
            {

                int choice2 = 1;

                foreach (Course course in listOfCourse)
                {
                    Console.WriteLine($"Title of the Course is : {course.Title},  Duration : {course.DurationInMonths}");
                }

                ForMemoryAllocation_Validation(ref choice2, "\nEnter 1 or 2 or 3.. for Select a Course for Batch..");
                if (choice2 > 0 && listOfCourse.Count() >= choice2)
                {
                    batch.CourseId = listOfCourse.ToArray()[choice2 - 1].Id;
                    tag = 0;
                }
                else
                {
                    Console.WriteLine("Enter valid choice");
                }

            }
            return batch;
        }

    }
}
