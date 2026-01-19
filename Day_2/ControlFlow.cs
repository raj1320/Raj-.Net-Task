using System;

public class ControlFlow
{

  
    static void Main()
	{
		double Marks =0;
        
        string? userInput;
        Console.WriteLine("Enter The marks:");
        userInput = Console.ReadLine();
        if (!double.TryParse(userInput, out Marks) && Marks>0)
        Console.WriteLine("Invalid input. Please enter a valid number:");
      

        char grade;

        // Grade assign by if else..
        if (Marks > 75) grade = 'A';
        else if (Marks >= 60) grade = 'B';
        else if (Marks >= 50) grade = 'C';
        else if (Marks >= 34) grade = 'D';
        else grade = 'F';

        Console.WriteLine("Your Garde is (via if else) : " + grade);

        // Grade assign by Switch case..
        switch (Marks)
        {
            case double m when m > 75:
                grade = 'A';
                break;
            case double m when m >= 60:
                grade = 'B';
                break;
            case double m when m >= 50:
                grade = 'C';
                break;
            case double m when m >= 34:
                grade = 'D';
                break;
            default:
                grade = 'F';
                break;
        }


        Console.WriteLine("Your Garde is (via Switch statement) : " + grade);
	}
}
