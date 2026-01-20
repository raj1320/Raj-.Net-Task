using System;
using System.Collections.Generic;

// student class
public class Student
{
    public int Id;
    int Age;
    string Name;
    string City;

    public Student(int Id, int Age, string? Name, string? City)
    {
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

    public static void UpdateName(string? newName, Student std)
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

//Dictionary class
public class ArraysCollections_Dictionary
{
    // for student Id..
    static int Base_id = 100;

    // get the user input and check whether it is a number or not
    public static void MemoryAllocation_Validation(ref int Num, string msg) 
    {
        string? userInput;
        Console.WriteLine($"{msg} ");
        userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
    }

    // add new student to the dictionary
    public static void AddStudent(Dictionary<int, Student> students)
    {

        Console.WriteLine("Enter the name of the student: ");
        string? Name = Console.ReadLine();
        Console.WriteLine("Enter the City of the student: ");
        string? City = Console.ReadLine();
        int Age = 0;
        MemoryAllocation_Validation(ref Age, "Enter the Age of the student : ");

        Student st1 = new Student(Base_id++, Age, Name, City);
        students.Add(Base_id-1, st1);
        return;
    }

    // modified student object
    public static void updateStudent(int id, Dictionary<int,Student> students)
    {
        Student? obj = null;
        foreach (KeyValuePair<int, Student> kvp in students)
        {
            if (kvp.Key == id)
            {
                obj = kvp.Value;
                break;
            }
        }
   
        if (obj == null)
        {
            Console.WriteLine("Enter valid id");
            return;
        }
        Console.WriteLine("1 for Update Name..");
        Console.WriteLine("2 for Update City..");
        Console.WriteLine("3 for Update Age..");
        int caseValue = 0;
        MemoryAllocation_Validation(ref caseValue, "Case :");


        switch (caseValue)
        {
            case 1:
                {
                    Console.WriteLine("Enter the name of the student: ");
                    string? Name = Console.ReadLine();
                    Student.UpdateName(Name, obj);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter the City of the student: ");
                    string? City = Console.ReadLine();
                    Student.UpdateCity(City, obj);
                    break;
                }
            case 3:
                {
                    int Age = 0;
                    MemoryAllocation_Validation(ref Age, "Enter the Age of the student: ");
                    Student.UpdateAge(Age, obj);
                    break;
                }
        }
        Console.WriteLine("Here is the updated Student!..");
        Student.display(obj);
    }

    // delete student record 
    public static void DeleteStudent(int id, Dictionary<int, Student> students)
    {
        Student? obj = null;
        foreach (KeyValuePair<int, Student> kvp in students)
        {
            if (kvp.Key == id)
            {
                obj = kvp.Value;
                break;
            }
        }
        if (obj == null)
        {
            Console.WriteLine("No object is selected");
            return;
        }
        students.Remove(obj.Id);

        Console.WriteLine("Value Deleted Successfully, current state is :");
        displayDictonary(students);

    }

    // display student Dictonary
    public static void displayDictonary(Dictionary<int, Student>  students)
    {
        if (students.Count == 0) { Console.WriteLine("Empty Dictionary.."); return; }
        Console.WriteLine("=============================");
        foreach (KeyValuePair<int,Student> kvp in students)
        {
            Student.display(kvp.Value);
            Console.WriteLine("=============================");
        }
    }

    // display student record
    public static void displayStudent(int id, Dictionary<int, Student> students)
    {
        int flag = 1;
        foreach (KeyValuePair<int, Student> kvp in students)
        {
            if (kvp.Key == id)
            {
                Student.display(kvp.Value);
                flag = 0;
                break;
            }
        }
        Console.WriteLine("=============================");
        if (flag == 1) Console.WriteLine("NO record found!");
    }

    static void Main(string[] args)
    {

        Dictionary< int,Student> students = new Dictionary<int,Student>();
        int value = 0;

        while (value != 4)
        {
            Console.WriteLine("============================");
            Console.WriteLine("Enter 0 for Add Students");
            Console.WriteLine("Enter 1 for Display Student");
            Console.WriteLine("Enter 2 for Update Student");
            Console.WriteLine("Enter 3 for Delete Student");
            Console.WriteLine("Enter 4 for EXIT");


            MemoryAllocation_Validation(ref value, "Enter The case");
            switch (value)
            {
                case 0:
                    {
                        AddStudent(students);
                        displayDictonary(students);
                        break;
                    }
                case 1:
                    {
                        int idx = 0;
                        MemoryAllocation_Validation(ref idx, "Enter the id of student for Search it: ");
                        displayStudent(idx, students);
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
                        int idx = 0;
                        MemoryAllocation_Validation(ref idx, "Enter the id of student to Delete it: ");
                        DeleteStudent(idx, students);
                        break;
                    }

            }
        }

    }

}
