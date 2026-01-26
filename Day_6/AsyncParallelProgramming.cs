using System;
using System.Threading.Tasks;
using System.Diagnostics;
public class AsyncParallelProgramming
{
    // simulated Api call for Async function
    public static async Task<string> SimulatedApiCallForAsync(string str)
    {
        await Task.Delay(1000);
        return str;

    }

    // simulated Api call for Sync function
    public static string SimulatedApiCallForSync(string str)
    {
        Thread.Sleep(1000);
        return str;

    }

    // Api call function for Sync function
    public static void ApiCallForSync()
    {

        Stopwatch TimerForSync = Stopwatch.StartNew();

        // this code run syncronously 
        string str1 = SimulatedApiCallForSync("sync call by t1...");
        string str2 = SimulatedApiCallForSync("sync call by t2...");
        string str3 = SimulatedApiCallForSync("sync call by t3...");


        TimerForSync.Stop();

        Console.WriteLine($"{str1}\n{str2}\n{str3}");
        Console.WriteLine(TimerForSync.Elapsed.Seconds + " second");


    }

    // Api call function for Async function without parallel Execution
    public static async Task ApiCallForAsyncBehaveLikeSyncDueToawait()
    {

        Stopwatch TimerForASync = Stopwatch.StartNew();

        string task1 = await SimulatedApiCallForAsync("Async call by t1...");
        string task2 = await SimulatedApiCallForAsync("Async call by t2...");
        string task3 = await SimulatedApiCallForAsync("Async call by t3...");


        TimerForASync.Stop();


        Console.WriteLine($"{task1}\n{task2}\n{task3}");
        Console.WriteLine(TimerForASync.Elapsed.Seconds + " second");


    }

    // Api call function for Async function with parallel Execution withot thread blocking 
    public static async Task ApiCallForAsyncBehaveLikeParallelDueToaTaskWhenAll()
    {

        Stopwatch TimerForASync = Stopwatch.StartNew();

        Task<string> task1 = SimulatedApiCallForAsync("Async call of parallel execution by t1...");
        Task<string> task2 = SimulatedApiCallForAsync("Async call of parallel execution by t2...");
        Task<string> task3 = SimulatedApiCallForAsync("Async call of parallel execution by t3...");

        string[] result = await Task.WhenAll(task1, task2, task3);

        TimerForASync.Stop();

        foreach (string str in result) Console.WriteLine(str);

        Console.WriteLine(TimerForASync.Elapsed.Seconds + " second");

    }


    // second method :- we can make this class async and use the await keyword at next to the GetDataAsync Method for make it wrokable.
    static async Task Main(string[] args)
    {

        // Api call for Sync function
        ApiCallForSync();
        Console.WriteLine("==================");

        // Api call for Async function without parallel Execution
        await ApiCallForAsyncBehaveLikeSyncDueToawait();
        Console.WriteLine("==================");

        // Api call for Async function with parallel Execution withot thread blocking 
        await ApiCallForAsyncBehaveLikeParallelDueToaTaskWhenAll();
        Console.WriteLine("==================");


        
        // So thats while i am running the code both takes Same time to execute in case of ApiCallForSync() and ApiCallForAsyncBehaveLikeSyncDueToawait();
        
        /*     In case of ApiCallForAsyncBehaveLikeParallelDueToaTaskWhenAll() function call,
               it will take less time with compare to ApiCallForSync() and ApiCallForAsyncBehaveLikeSyncDueToawait()
               Due to Task.WhenAll Method Which execute each task parallely and comelete after each task commplete
        */

    }

}