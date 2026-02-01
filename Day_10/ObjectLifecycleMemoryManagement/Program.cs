using ObjectLifecycleMemoryManagement;
using System;

class Program
{
    static void Main()
    {
        // Use a using-statement so the logger is disposed automatically when the block completes.
        // Disposal should flush and release file handles held by `FileLoggern`.
        using (var logger = new FileLoggern("log.txt"))
        {
            logger.Log("Application Started");
            logger.Log("Performing Task");
            logger.Log("Application ended");
        }
    }
}