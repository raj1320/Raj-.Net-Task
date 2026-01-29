using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedInheritance
{
    internal class TestProgram
    {
        static void Main()
        {
            Baseclass Obj = new DerivedClass();

            // When i execute this code then it will call the method of derived class due to it override this method. 
            Obj.Print1to10Number();
            // When i execute this code then it will call the method of Base class due to it checks referance at run time and call parent class function.
            Obj.Print1to5Number();

        
            Console.WriteLine("\n================================");
            


            DerivedClass Obj2 = new DerivedClass();

            // When i execute this code then it will call the method of derived class due to it override this method. 
            Obj2.Print1to10Number();
            // When i execute this code then it will call the method of Base class due to it checks referance at run time and call derived class function.
            Obj2.Print1to5Number();
        }
    }
}



