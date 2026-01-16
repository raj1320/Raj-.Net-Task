using System;

public class CallByValueAndCallByReference
{
	public static void callByvalue(int val1,int val2)
	{
		val1 = 30;
		val2 = 40;
	}

    public static void callByReference(ref int val1,ref int val2)
    {
        val1 = 30;
        val2 = 40;
    }

    static void Main(string[] Args)
	{
		int val1 = 10;
		int val2 = 20;
        
        Console.WriteLine("========================================================================");

        Console.WriteLine("Before Calling CallByValue Function val1 & val2 : " + val1 + " " + val2);

		callByvalue(val1, val2);

        Console.WriteLine("After Calling CallByValue Function val1 & val2 : " + val1 + " " + val2);

        Console.WriteLine("========================================================================");


        Console.WriteLine("Before Calling CallByReference Function val1 & val2 : " + val1 + " " + val2);

        callByReference(ref val1,ref val2);

        Console.WriteLine("After Calling CallByReference Function val1 & val2 : " + val1 + " " + val2);

        Console.WriteLine("========================================================================");

    }
}
