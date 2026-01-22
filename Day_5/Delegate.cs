using System;

// Delegate declaration 
public delegate void DelegateForPrintPerson(Person p);

// Just a class of Person having two methods with same perameter
public class Person
{
	string Name;
	string Address;
	long PhoneNumber;


	public Person(string Name,string Address,long PhoneNumber)
	{
		this.Name = Name;
		this.Address = Address;
		this.PhoneNumber = PhoneNumber;
	}

    public static void Printperson(Person p)
	{
		Console.WriteLine($"This is a name of Persone: {p.Name}");
		Console.WriteLine($"This is a Address of Persone: {p.Address}");
        Console.WriteLine($"This is a name of Persone: {p.PhoneNumber}");
    }
    public static void PrintpersonInOneLine(Person p)
    {
        Console.WriteLine($"This is a name of Persone: {p.Name} , This is a Address of Persone: {p.Address} , This is a name of Persone: {p.PhoneNumber}");
    }
}

// delegate usage
public class DelegateUseCase
{
	static void Main()
	{
		Person person = new Person("Raj","Khambhat",7046192318);
		// delegate referance is created..
		DelegateForPrintPerson p1 = Person.Printperson;
		//Add another method to delegate
		p1 += Person.PrintpersonInOneLine;
	
		// invocation happens
		p1.Invoke(person);
        Console.WriteLine("=========================");
       
		p1.Invoke(new Person("Ravi", "Sutrapada", 7046192318));
		
		Console.WriteLine("=========================");
		
		// remove second method from delegate
		p1 -= Person.PrintpersonInOneLine;
		p1.Invoke(person);


		//Code for My learning purpose...
		//Delegate[] invocationList = p1.GetInvocationList();
		//foreach(DelegateForPrintPerson item in invocationList.OfType<DelegateForPrintPerson>()){
		//Console.WriteLine(item.Method.Name);
		//}

	}
}