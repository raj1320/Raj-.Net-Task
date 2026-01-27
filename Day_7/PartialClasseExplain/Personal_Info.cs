using System;
namespace Classes_Object_Constructor_AccessModifiers_2
{
    partial class Student
    {
        string _Name= string.Empty;
        string _Address = string.Empty;
        int _Age;
        long _Phone;

        // getter & setter
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public int Age { get { return _Age; } set { if( value>0) _Age = value; } }
        public string Phone { get { return _Phone.ToString(); } set { if(value.Length==10) _Phone = long.Parse(value); } }

        // Constructor One
        public Student(string? name, string? address, int age, long phone)
        {
            this.Name = name ?? "std";
            this.Address = address ?? "add";
            this.Age = age;
            this.Phone = phone.ToString();
        }


    }
    internal class Personal_Info
    {
        static void Main()
        {
            Student student = new Student("Rana Raj", "Khambhat", 21, 1234567890);

            // Display field manually
            Console.WriteLine();
            Console.WriteLine("student Name is : "+ student.Name);
            Console.WriteLine("student Age is : " + student.Age);
            Console.WriteLine("student Phone Number is : "+ student.Phone);
            Console.WriteLine("student Address is : "+ student.Address);
          
            
        }
       

    }
}
