using System;

public class MethodsFunction
{
    public static double Addition(double val1, double val2)
    {
        return val1 + val2;
    }

    public static double Substraction(double val1, double val2)
    {
        return val1 - val2;
    }

    public static double Multiply(double val1, double val2)
    {
        return val1 * val2;
    }

    public static double Division(double val1, double val2)
    {
        if (val2 == 0)
        {
            Console.WriteLine("Division is not possible");
            return 0;
        }
        return val1 / val2;
    }

    public static double Modulo(double val1, double val2)
    {
        return val1 % val2;
    }

    public static void OptionalPerameterFunction(string greetings = "Welcome to Optional perameter function")
    {
        Console.WriteLine(greetings); 
    }


    public static void OutKeyWordFunction(out double val)
    {
        string? userInput;

        Console.WriteLine("Enter value one for Arithmatic operations:");
        userInput = Console.ReadLine();

        if (!double.TryParse(userInput, out val)) // return true if condition false visa versa due to '!' oparetor ...  
        {
            Console.WriteLine("Enter valid value");
            return;
        }
    }

    static void Main(string[] args)
    {

        OptionalPerameterFunction();  //just printing the message nothing else!
        
        double val1;
        double val2;
       
        OutKeyWordFunction(out val1); // assign value to the val1 after ansuring valid data type & parsing..
        OutKeyWordFunction(out val2); // assign value to the val2 after ansuring valid data type & parsing..




        Console.WriteLine($"Addition of two number is:{Addition(val1,val2)}");
        Console.WriteLine($"Substraction of two number is:{Substraction(val1, val2)}");
        Console.WriteLine($"Multiply of two number is:{Multiply(val1, val2)}");
        Console.WriteLine($"Division of two number is:{Division(val1, val2)}");
        Console.WriteLine($"Modulo of two number is:{Modulo(val1, val2)}");

    }

}
