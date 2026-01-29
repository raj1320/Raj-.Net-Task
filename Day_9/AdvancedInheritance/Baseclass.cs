using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedInheritance
{
    internal class Baseclass
    {
        public virtual void Print1to10Number()
        {
            Console.WriteLine("\nYou are in Base class\n");
            for(int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }

        public virtual void Print1to5Number()
        {
            Console.WriteLine("\n\nYou are in Base class\n");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
            }
        }

    }
}
