using System;

public class Operators
{

  

	static void Main(string[] args)
	{
        double number;
        double val1 = 0;
        double val2 = 0;

        int select_case = 0;
        int test = 0;

        while (select_case!=8)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("select_case:");
            Console.WriteLine("Select 0 for Addition:");
            Console.WriteLine("Select 1 for Substraction:");
            Console.WriteLine("Select 2 for Multiplication:");
            Console.WriteLine("Select 3 for Division:");
            Console.WriteLine("Select 4 for Greater or Equal compare:");
            Console.WriteLine("Select 5 for Smaller or Equal compare:");
            Console.WriteLine("Select 6 for Equals compare:");
            Console.WriteLine("Select 7 for Add one to both the values:");
            Console.WriteLine("Enter 8 for Exite:");


            // memory assign after validating input
            string? userInput = Console.ReadLine();
            if (int.TryParse(userInput, out test)) select_case = test;
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                continue;
            }

            if (select_case >= 8)
            {
                Console.WriteLine("Thankyou! for using me!");
                return;
            }


            // memory assign after validating input
            Console.WriteLine("Enter First Value:");
            userInput = Console.ReadLine();
            if (double.TryParse(userInput, out number))
                val1 = number;
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                continue;
            }

            // memory assign after validating input
            Console.WriteLine("Enter second value:");
            userInput = Console.ReadLine();
            if (double.TryParse(userInput, out number)) 
                val2 = number;
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                continue;
            }



            switch (select_case)
            {
                case 0:
                    {
                        Console.WriteLine("Addition of two Number:" + (val1 + val2));
                        Console.WriteLine("=======================================================");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Substraction of two Number:" + (val1 - val2));
                        Console.WriteLine("=======================================================");

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Multiplication of two Number:" + (val1 * val2));
                        Console.WriteLine("=======================================================");

                        break;
                    }
                case 3:
                    {
                        if (val2 == 0)
                        {
                            Console.WriteLine("Divison is not possible");
                            Console.WriteLine("=======================================================");
                            break;
                        }

                        Console.WriteLine("Division of two Number:" + (val1 / val2));
                        Console.WriteLine("=======================================================");
                        break;
                    }
                case 4:
                    {
                        double result = 0;
                        result = val1 >= val2 ? val1 : val2;
                        Console.WriteLine("Greater or Equal Value is:" + result);
                        Console.WriteLine("=======================================================");
                        break;
                    }
                case 5:
                    {
                        double result = 0;
                        result = val1 >= val2 ? val2 : val1;
                        Console.WriteLine("Smaller or Equal value is:" + result);
                        Console.WriteLine("=======================================================");
                        break;
                    }
                case 6:
                    {
                        Console.Write("Check for Equals or not:");
                        if (val1 == val2) Console.WriteLine("True");
                        else Console.WriteLine("False");
                        Console.WriteLine("=======================================================");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Add one to both the values");
                        val1 += 1;
                        val2 += 1;
                        Console.WriteLine("Updated Value of Value one is:" + val1);
                        Console.WriteLine("Updated Value of Value two is:" + val2);
                        Console.WriteLine("=======================================================");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Enter valid case");
                        Console.WriteLine("=======================================================");
                        break;
                    }


            }
        }
    }
}
