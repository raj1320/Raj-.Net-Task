using System;
using NameSpaceExample.NamespaceForClass1; // this is a different namespace name for same class example 
using NameSpaceExample.NamespaceForClass2;

namespace NameSpaceExample
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("We are in Program class");
            // Example.Print();  this line create conflict due to same class name from two diffrenet namespace so make sure not use this syntext
            NamespaceForClass1.Example.Print(); // this line resolve the conflict of same class name
            NamespaceForClass2.Example.Print(); // this line resolve the conflict of same class name
        }

    }

}
