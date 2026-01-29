using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedInheritance
{
    internal class DerivedClass : Baseclass
    {
        // override method with the help of  Override keyword
        public override void Print1to10Number()
        {
            Console.WriteLine("\nYou are in Derived class\n");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i+" ");
            }
        }

        // override method with the help of new keyword
        public new void Print1to5Number()
        {
            Console.WriteLine("\n\nYou are in Derived class\n");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
            }
        }

    }
}
