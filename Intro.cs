using System;

public class Intro
{
	static void Main(String []args)
	{
		string MachineName = Environment.MachineName;
		DateTime date = DateTime.Today;

		Console.Write("===========================\n");
		Console.WriteLine("Rana Raj");
		Console.WriteLine("Today Date is : "+ date);
		Console.WriteLine("Machine Name is : " + MachineName);
        Console.Write("===========================\n");

    }
}
