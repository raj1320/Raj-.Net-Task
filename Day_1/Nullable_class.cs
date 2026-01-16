using System;

public class Nullable_class
{
	 string Name="USER";
	 int age=18;
	 string address="ADDRESS";

	public Nullable_class()
	{

	}

	public Nullable_class(string? Name,int? age,string? address){
		this.Name = Name ?? "USER"; 
		this.age = age ?? 18;
		this.address = address ?? "ADDRESS";
     }

	 public static void display(Nullable_class obj)
	{
		Console.WriteLine("Name is : " + obj.Name);
        Console.WriteLine("Age is : " + obj.age);
		Console.WriteLine("Address is : " + obj.address);
    }

	

    static void Main(string[] args)
	{
		

        Nullable_class obj1 = new Nullable_class("Raj",21,null);
		display(obj1);






		Console.WriteLine("=========================================================================");
		string? name_of_user = "Raj";
        int? age_of_user = 21;
        string? address_of_user = null;

		
	    Console.WriteLine("Name is : " + (name_of_user ?? "USER")); 
        Console.WriteLine("Address is :" + (address_of_user ?? "ADDRESS"));
        
		//HashValue is onnly applicable to Nullable value type not applicable to Nullable Reference Type(string.. etc.);
		if (age_of_user.HasValue)
        {
            Console.WriteLine("Age is : " + age_of_user);
        }
        else
        {
            Console.WriteLine("Age is :" + 18);
        }
        

    }
}
