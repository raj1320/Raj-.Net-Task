using System;

public class BoxingUnBoxing
{
     static void Main(string[] args)
    {
        // Example of Boxing...
        int IamValueType = 1234444;
        object IamObjectType = IamValueType; // this is what boxing is,it implisitly copy the value of varible in heap and assign refference to the xyz Object.
        Console.WriteLine(IamObjectType);


        IamValueType = (int)IamObjectType; // This is Unboxing 
        Console.WriteLine(IamValueType);


    }
}
