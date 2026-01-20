using System;
using System.Collections.Generic;
public class Loops
{
    // get the user input and check whether it is a number or not
    public static void MemoryAllocation_Validation(ref int Num)
    {
        string? userInput;
        Console.WriteLine("Enter the Number:");
        userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
    }

    // Prime number printing..
	public static void PrimeNumbers()
	{
        int Num=0;

        Console.WriteLine("Welcome to the Prime Number Programme...");
        MemoryAllocation_Validation(ref Num);

        Console.WriteLine("===================================");
        for (int i = 0; i < Num; i++)
        {
            int count = 1;
            for (int j = 2; j <i*i ; j++)
            {
                if (i % j == 0) count++;
            }
            if (count == 2) Console.WriteLine(i);
        }
        Console.WriteLine("=====================================");

    }

    // print List items
    public static void PrintList(List<int> list)
    {
        foreach(int i in list)
        {
            Console.WriteLine(i);
        }
    }

    // Guess the number game function
    public static void GuessTheNumber()
    {
        int Num = 0;
        int Guessvalue = Random.Shared.Next(1,10);
        Console.WriteLine("Welcome to the GuessNumber Game.. from 0 to 10 (inclusive).");
        
        while (Num!=Guessvalue)//compare the 
        {
            MemoryAllocation_Validation(ref Num); // get the value from user & validate it.
        }
        
        Console.WriteLine("Congrats you are winner!");
    }

    static void Main(string[] args)
	{
        List<int> li = new List<int> { 1,2,3,4,5};
       
        PrimeNumbers();
    
        PrintList(li);

        GuessTheNumber();
		
	}
}
