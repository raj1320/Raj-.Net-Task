using System;
using System.Collections.Generic;
public class LamdaExpression
{
    // swaping by condition check
    public static void updatedList(List<int> list,int i,int n)
    {
        if (i==n-1) return;

        if (list[i] > list[i+1])
        {
            int temp=list[i+1];
            list[i+1]=list[i];
            list[i] = temp;
        }
   
        updatedList(list,i+1,n);
     }

    // iterate from 0 to size of array
    public static void SortingArray(List<int> list,int n)
    {
        if (n==1) { return; }
        updatedList(list,0,n);
        SortingArray(list,n-1);
        
    }

    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5, 6 };

        // filter apply using lamda expression and where method of Array
        int[] ans = arr.Where(x => x % 2 == 0).ToArray();
        Console.WriteLine("Filtered value is:");
        foreach (int x in ans) Console.WriteLine(x);



        // Prinitng a max value from Array
        int max = arr[0];
        arr.ToList().ForEach(x => { if (max < x) max = x; });
        Console.WriteLine("Max value from array is :" + max);

        List<int> list = new List<int>(){ 99,10,25,63,74,65,26,37,48,59};



        Console.WriteLine("\n\nSort list by uing recursion:");
        SortingArray(list,list.Count());
        list.ForEach(x => Console.Write($"{x} "));

        // another way is using sort method 

        Console.WriteLine("\n\nSort list by uing Sort method of List:");
        list.Sort();

        list.ForEach(x => Console.Write($"{x} "));


    }
}