using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;
public class ConcurrentCollectionsAndThreadBehaviour
{
    // Concurrent  Collection
    public static ConcurrentBag<int> conBag = new ConcurrentBag<int>();
   
    // Treditional Collection
    public static List<int> list = new List<int>();

    // This is Activity perform on Concurrent Collection using parallel for loop  
    public static void Activity1()
    {
        Parallel.For(0, 1000, i =>
        {
            Thread.Sleep(5000);
            Console.WriteLine("From Acitivity one: "+i);
            conBag.Add(i);
        });

    }

    // This is Activity perform on Treditional Collection using parallel for loop
    public static void Activity2()
    {
        Parallel.For(0, 1000, i =>
        {
            Thread.Sleep(5000);
            Console.WriteLine("From Acitivity Two: "+i);
            list.Add(i);
        });
    }

    //Display parallel execution
    public static void Display<Gen>(IEnumerable<Gen> collection)
    {
        Console.WriteLine(collection.Count());
    }

    static void Main()
    {
        // Threadstart delegate declare manually  we can directly pass the function in Thread constructor as well.
        ThreadStart task1 = Activity1;
        ThreadStart task2 = Activity2;

        // Assign Threadstart delegate to Thread 
        Thread th1 = new Thread(task1);
        Thread th2 = new Thread(task2);

        // Start the Execution
        th1.Start();
        th2.Start();

        // Join working Threads with main Thread
        th1.Join();
        th2.Join();

       // Dispaly the end count of collection one after another
       Console.WriteLine($"It is the List size of Concurrent Collection :");
       Display(conBag);
       Console.WriteLine($"It is the List size of Treditional Collection : ");
       Display(list);
       Console.WriteLine("Main Thread Execution ended...");


        /*
         
           One major observation i took when i increase the count of 'i' 
           Teditional collection override some indexes and not provide exact count of 'i' at the end of execution 
           wherase Concurrent collection provide exact count not override any index.
        
         */
    }
}


