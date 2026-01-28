using System;
using System.Collections.Generic;

namespace Encapsulation
{
    // TemperatureMonitor class
    public class TemperatureMonitor
    {
        // private fields & collections 
        float _Temperature;
        List<float> _History = new List<float>();

        // Properties 
        public float Temperature
        {
            get
            {
                return _Temperature;
            }
            set
            {
                if (value >= 0)
                {
                    History.Add(_Temperature);
                    _Temperature = value;
                }
                else
                {
                    Console.WriteLine("Enter valid Temprature.");
                }


            }
        }
        public List<float> History
        {
            get { return _History; }
        }


        public void DisplayHistory()
        {
            int count = 0;
            foreach (float item in History)
            {
                Console.WriteLine($"Previous idx: {count++} Temprature: " + item + " in celsius");
            }

            Console.WriteLine($"Current idx: {count} Temprature is : " + this.Temperature + " in celsius");
        }
    }

    class TemperatureMonitor_User
    {
        public static void MemoryAllocation_Validation(ref float Num, string msg)
        {
            string? userInput;
            Console.WriteLine($"{msg} ");
            userInput = Console.ReadLine();
            if (!float.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
        }

        static void Main()
        {

            // Creating a referance & object of TempratureMoniter class 
            TemperatureMonitor TempUserOne = new TemperatureMonitor();



            // Getting user value & validate it also
            float input = 0f;
            MemoryAllocation_Validation(ref input, "Enter Tamprature in celsius : ");
            TempUserOne.Temperature = input;



            // Display history of Temprature
            TempUserOne.DisplayHistory();



            string choice = "yes";
            while (!choice.ToLower().Equals("No"))
            {
                // Asking for change the value of current Temprature
                Console.WriteLine("Would you like to change Temprature then enter Yes/yes else no/No: ");
                choice = Console.ReadLine() ?? "Yes";
                if (choice.ToLower().Equals("no")) break;

                // Aking for continue or exit
                input = 0;
                MemoryAllocation_Validation(ref input, "\nEnter Tamprature in celsius : ");
                TempUserOne.Temperature = input;
                TempUserOne.DisplayHistory();
            }



        }
    }
}
