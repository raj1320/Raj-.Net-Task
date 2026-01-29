using System;
using System.Collections.Generic;
using System.Text;


namespace InheritanceAndMethodOverriding.BaseExplore
{
    internal class BaseClass
    {
        // Parameterless Constructor
        public BaseClass()
        {
            Console.WriteLine("\nYou are in Base class");
            Console.WriteLine("Child Object is Created Uing Parameterless Constructor");
            Console.WriteLine($"Time of Oject Creation is : {DateTime.Now}");
        }
        // Parameterized Constructor
        public BaseClass(Object obj)
        {   
            Console.WriteLine("\nYou are in Base class");
            Console.WriteLine("Child Object is Created Uing Parameterized Constructor");
            Console.WriteLine($"Time of Oject Creation is : {DateTime.Now}");
            Console.WriteLine("\nUserName and Purpose\n" + obj.ToString());

        }
    }
}
