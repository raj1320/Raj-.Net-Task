using System;

public class ReadOnly_constant_class
{

	readonly int Id = 0;
    string Email = "user123@gmail.com";
	string Name = "User";
	int Phone = 1234567890;

	public ReadOnly_constant_class()
	{

	}

	public ReadOnly_constant_class(string? Email,string? Name,int? Phone,int Base){

		this.Id = Base + 1;
		this.Email = Email ?? "user123@gmail.com";
		this.Name = Name ?? "User";
		this.Phone = Phone ?? 1234567890;

    }


	public static void display(ReadOnly_constant_class obj)
	{
		Console.WriteLine("Id: " + obj.Id);
		Console.WriteLine("Name: " + obj.Name);
        Console.WriteLine("Emial: " + obj.Email);
        Console.WriteLine("Phone: " + obj.Phone);
    }



    static void Main(string[] args)
	{
		const int Base = 10;

		ReadOnly_constant_class obj = new ReadOnly_constant_class("ranaroshan1232005@gmail.com","Rana Raj",null,Base);
		//obj.Id = 12;

		//Const int new_Id = 20;
		//new_Id =  30;

		display(obj);


    }

}
