///<summary>
/// Here i define StudentClass with 3 private fields 
/// And one static method Called AddStudentsToList which adds dummy data to list and returns StudentsToList List.
/// </summary>



using System;
using System.Collections.Generic;
using System.Text;

namespace linqTasksDay3
{
    internal class StudentClass
    {

        static int NO = 1;

        private int _RollNo;
        private string _Name = string.Empty;
        private int _Marks;


        public StudentClass(int rollNo, string name, int marks)
        {
            this.RollNo = rollNo;
            this.Name = name;
            this.Marks = marks;
        }

        public static List<StudentClass> AddStudentsToList()
        {
            List<StudentClass> studentList = new List<StudentClass>()
            {
                new StudentClass(NO++,"Raj",85),
                new StudentClass(NO++,"Tushar",45),
                new StudentClass(NO++,"Mahi",33),
                new StudentClass(NO++,"Niket",75),
                new StudentClass(NO++,"Navin",65),
                new StudentClass(NO++,"Priya",86),
                new StudentClass(NO++,"Karan",32),
                new StudentClass(NO++,"Shivani",52),
                new StudentClass(NO++,"Jiya",82),
                new StudentClass(NO++,"Sonam",56),
                new StudentClass(NO++,"Vishal",32),
                new StudentClass(NO++,"Tarun",84),
                new StudentClass(NO++,"Kavya",65),
                new StudentClass(NO++,"Kisha",32),
                new StudentClass(NO++,"Rahul",31),
                new StudentClass(NO++,"Kishan",50),
                new StudentClass(NO++,"Vijay",30),
                new StudentClass(NO++,"Naman",30),
                new StudentClass(NO++,"Akash",29)

            };

            return studentList;
        }

        public int RollNo
        {
            get { return _RollNo; }
            set { _RollNo = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public int Marks
        {
            get { return _Marks; }
            set { _Marks = value; }
        }
    }

}
