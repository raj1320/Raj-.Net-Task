using System;
using System.Linq;
public static class ExtentionMehtods
{
	// this is a constructed meethod for string to capitalizedd the first charector of every latter
	public static string ToCapitalize(this string s1){

		string str = "";
		      
		// it trims --> convert to lowercase --> split in array --> covert in list --> create individuale string from original one
		s1.Trim().ToLower().Split(' ').ToList().ForEach(x =>
		{
			str += char.ToUpper(x[0])+x.Substring(1)+" ";
		});

		return str.Trim();
	}
    // this is a constructed meethod for string to add Underscore to the first charector and capitalized every latter
    public static string ToAddUnderscoreAndInUpper(this string s1)
	{
        string str = "";
        // it trims --> convert to lowercase --> split in array --> covert in list --> create individuale string from original one
        s1.Trim().ToLower().Split(' ').ToList().ForEach(x =>
        {
            str += "_" + x.ToUpper()+" ";
			
        });
		return str.Trim();
	}
}

public class ExtentionMehtodsExample
{
	static void Main()
	{
        string mystr = "hello i am raj!";
        Console.WriteLine("String Before: "+mystr);
        // Extention method used 
        mystr = mystr.ToCapitalize();
        Console.WriteLine("String After using ToCapitalize:  " + mystr);
		// Extention method second example
        mystr = mystr.ToAddUnderscoreAndInUpper();
        Console.WriteLine("String After using ToAddUnderscoreAndInUpper:  " + mystr);


    }
}
