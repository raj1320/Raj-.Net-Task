using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.ExplicitInterfaceSolution
{
    // Use Multiple Inheritance
    internal class InterfaceImplementation : IAuditing,ILogging
    {
        // Implements Two different interfance method having same name using Explicit Interface Mechanism 
        void IAuditing.AurthorityCheking(string ID, string Passwrod)
        {
            Console.WriteLine("You are in Aurthority Cheking from IAuditing interface implimentation");
            Console.WriteLine($"Your ID:{ID} and Password:{Passwrod}");
        }
        void ILogging.AurthorityCheking(string ID, string Passwrod)
        {
            Console.WriteLine("You are in Aurthority Cheking from ILogging interface implimentation");
            Console.WriteLine($"Your ID:{ID} and Password:{Passwrod}");
        }
    
        static void Main()
        {
           //One way to call different method having same name from one class
            IAuditing auditing = new InterfaceImplementation();
            ILogging logging = new InterfaceImplementation();

            // Method Calling
            auditing.AurthorityCheking("ghvhxx1232222", "#######");
            logging.AurthorityCheking("ewrewre535342", "#######");

            //// Second way to call different method having same name from one class
            //InterfaceImplementation obj = new InterfaceImplementation();
            //((IAuditing)obj).AurthorityCheking("cjjwk", "2234");
            //((ILogging)obj).AurthorityCheking("cjjwk", "2234");
        }

    }
}
