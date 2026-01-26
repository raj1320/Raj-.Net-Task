using System;
using System.Threading.Tasks;
using System.Diagnostics;
class TaskWhenAllProgram
{
    // simulated Api call for Async function
    public static async Task<string> SimulatedApiCallForAsync(string str)
    {
        await Task.Delay(1000);
        return str;

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

    static async Task Main()
    {
        // Api call for Async function with parallel Execution withot thread blocking 
        await ApiCallForAsyncBehaveLikeParallelDueToaTaskWhenAll();
        
        Console.WriteLine("Using Task.WheAll every Tasks executed parallely and Complated unless and untill every task complete");
        Console.WriteLine("==================");

        /*    In case of ApiCallForAsyncBehaveLikeParallelDueToaTaskWhenAll() function call,
              it will take less time with compare to ApiCallForSync() and ApiCallForAsyncBehaveLikeSyncDueToawait()
              Due to Task.WhenAll Method Which execute each task parallely and comelete after each task commplete
       */
    }
}