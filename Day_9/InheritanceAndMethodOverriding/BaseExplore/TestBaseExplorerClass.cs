using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndMethodOverriding.BaseExplore
{
    internal class TestBaseExplorerClass
    {
        static void Main()
        {
            // First Base class Parameterless constructor call then derived class code execute
            DerivedClass derivedClass = new DerivedClass();
            
            Console.WriteLine("===========================");
           
            // First Base class Parameterized constructor call using base keyword then derived class constructor code execute
            DerivedClass newDerivedClass = new DerivedClass(new {Name="Raj", Purpose="Using Derived Class explore base keyword"});
            Console.WriteLine("===========================");
        }
    }
}
