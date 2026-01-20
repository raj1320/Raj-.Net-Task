using System;

// student class...
public class Student
{
    public int Id;
	int Age;
	string Name;
	string City;

	public Student(int Id,int Age,string? Name,string? City) {
		this.Id = Id;
		this.Age = Age;
		this.Name = Name ?? "Student";
		this.City = City ?? "XYZ";
	}

	public static void display(Student std)
	{
		Console.WriteLine($"Student Id is:{std.Id}");
		Console.WriteLine($"Student Name is : {std.Name}");
        Console.WriteLine($"Student Age is :{std.Age}");
        Console.WriteLine($"Student City is :{std.City}");
    }

	public static void UpdateName(string? newName,Student std)
	{
		std.Name = newName ?? "Student";
	}

    public static void UpdateAge(int newAge, Student std)
    {
        std.Age = newAge;
    }

	public static void UpdateCity(string? newCity, Student std)
	{
		std.City = newCity ?? "XYZ";
	}

}


//Array class
public class ArraysCollection_Array
{
	// for Student Id ...
	static int Base_id = 100;

    // get the user input and check whether it is a number or not
    public static void MemoryAllocation_Validation(ref int Num,string msg)
    {
        string? userInput;
        Console.WriteLine($"{msg} ");
        userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
    }
  
	// return new student object
	public static Student AddStudent()
	{
        Console.WriteLine("Enter the name of the student: ");
		string? Name = Console.ReadLine();
        Console.WriteLine("Enter the City of the student: ");
        string? City = Console.ReadLine();
		int Age=0;
		MemoryAllocation_Validation(ref Age, "Enter the Age of the student : ");
        Student st1 = new Student(Base_id++, Age, Name, City);
		return st1;
    }

	//update the student data
	public static void updateStudent(int id,Student[] students)
	{
		Student?obj=null;
		foreach(Student s in students)
		{
			if (s.Id == id) { obj = s; break; }
		}
		if (obj == null)
		{
			Console.WriteLine("Enter valid id");
			return;
		}
        Console.WriteLine("1 for Update Name..");
        Console.WriteLine("2 for Update City..");
        Console.WriteLine("3 for Update Age..");
        int caseValue=0;
		MemoryAllocation_Validation(ref caseValue, "Case :");


        switch (caseValue)
		{
			case 1:
				{
                    Console.WriteLine("Enter the name of the student: ");
                    string? Name = Console.ReadLine();
					Student.UpdateName(Name,obj);
					break;
                }
			case 2:
				{
                    Console.WriteLine("Enter the City of the student: ");
                    string? City = Console.ReadLine();
                    Student.UpdateCity(City,obj);
					break;
                }
			case 3:
				{
                    int Age=0;
					MemoryAllocation_Validation(ref Age, "Enter the Age of the student: ");
                    Student.UpdateAge(Age,obj);
					break;
                }
		}
		Console.WriteLine("Here is the updated Student!..");
        Student.display(obj);
	}
   
	//display the enire Array
    public static void displayArray(Student[] students)
	{
        foreach (Student st in students)
        {
            Student.display(st);
            Console.WriteLine("=============================");
        }
    }

	//display the search result
    public static void displayStudent(int id, Student[] students)
    {
        int flag = 1;
        foreach (Student st in students)
        {
            if (st.Id == id)
            {
                Student.display(st);
                flag = 0;
				break;
            }
            Console.WriteLine("=============================");
        }
        if (flag == 1) Console.WriteLine("NO record found!");
    }
   
	static void Main(string[] args)
	{
        
		//gate input from user to fix the size of an array
		int n=0;
		MemoryAllocation_Validation(ref n, "Enter the number of students do you want to add :");
		if (n == 0) return;
        Student[] students = new Student[n];
		int i = 0;
		while (i < n)
		{
			Student st= AddStudent();
			students[i] = st;
			i++;
        }
		// display the current Array state
		displayArray(students);


		//Provide option to interact with array
		Console.WriteLine("=============================");
		Console.WriteLine("Enter 1 for Search Students");
        Console.WriteLine("Enter 2 for Update Student");
        Console.WriteLine("Enter 3 for Display Students");
		
		int value = 0;
        MemoryAllocation_Validation(ref value, "Enter The case");
		switch (value)
		{
			case 1:
				{
                    int idx = 0;
                    MemoryAllocation_Validation(ref idx, "Enter the id of student for search it: ");
                    displayStudent(idx,students);
                    break;
                }
				
			case 2:
				{
					int idx = 0;
					MemoryAllocation_Validation(ref idx, "Enter the id of student for update it: ");
					updateStudent(idx, students);
					break;
				}
			case 3:
				{
					displayArray(students);
					break;
                }

        }

    }
}
