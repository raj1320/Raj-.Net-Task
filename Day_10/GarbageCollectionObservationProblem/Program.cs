/// <summary>
/// Instances print messages when constructed, and their finalizer writes a message
/// when the object is collected by the garbage collector. This class is used by
/// to show forced GC collection and finalizer execution.
/// </summary>
using System;
public class GCObservationClass
{
    int id;

    // Constructor
    public GCObservationClass(int id)
    {
        this.id = id;
        Console.WriteLine($"Constructor ,  Object {this.id} created.");
    }

    // Finalizer 
    ~GCObservationClass()
    {
        Console.WriteLine($"Finalizer , Object {this.id} finalized or collected.");
    }
}

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 5; i++)
        {
            GCObservationClass obj = new GCObservationClass(i);
        }

        Console.WriteLine("Forcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("End of program.");
    }
}