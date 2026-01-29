using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndMethodOverriding.BaseExplore
{
    internal class DerivedClass : BaseClass
    {
        // Call defualt parameterless costructor of Parent class without using Base key word  
        public DerivedClass() { Console.WriteLine("\ncontrole is Back in Derived Class\n"); }
       
        // Base keyword is use to call parent class parameterized constructor  
        public DerivedClass(Object Obj):base(Obj) 
        {
            Console.WriteLine("\ncontrole is Back in Derived Class");
            Console.WriteLine("Try to connect with Database.....");
            Console.WriteLine("Database connected successfully.....");
            Console.WriteLine("Object of UserName and Purpose is store Successfully...\n");
        }
    }
}
