using System;
namespace Classes_Object_Constructor_AccessModifiers_2
{
    partial class Student
    {
        static long RollSault = 20260;
        int _stdSatands = 6;
        string[] _subject = ["Hindi","English","Math"];
        long _RollNumber;

        public int stdStands { get { return _stdSatands; } set { _stdSatands = value; }  }
       
        // using Sread operator to add current array vlaue to the old value
        public string[] subject { get { return _subject; } set { _subject = [.._subject,..value]; }  }
        public long RollNumber { get { return _RollNumber; } }

        // Consider it as a second parameterized constructor
        public Student(string name, string address, int age, long phone, string[] subject, int StudentStands)
        {
            this.Name = name;
            this.Address = address;
            this.Age = age;
            this.Phone = phone.ToString();
            this._RollNumber = RollSault++;
            this.stdStands = StudentStands;
            this.subject = subject;
        }
        

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("student Name is : " + this.Name);
            Console.WriteLine("student Age is : " + this.Age);
            Console.WriteLine("student Phone Number is : " + this.Phone);
            Console.WriteLine("student RollNumber is : " + this.RollNumber);
            Console.WriteLine("student Class is : " + this.stdStands);
            Console.WriteLine("student subject List : ");
            foreach(string str in this.subject) Console.Write(" "+str+" ");
 
        }

    }
    internal class Academic_Info
    {
        static void Main()
        {
            Student student = new Student("Rana Raj", "Khambhat", 21, 1234567890, new[] {"Science","Soscial Sceince"} , 9);
            student.Display();

        }


    }
}
