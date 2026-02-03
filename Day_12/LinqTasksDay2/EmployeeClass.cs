///<summary>
/// Here i define EmployeeClass with 4 private fields 
/// And one static method Called AddEmployeeToList which adds dummy data to list and returns Employee List.
/// </summary>


using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTasksDay2
{
    internal class EmployeeClass
    {
        static int Id = 10000;

        private int _EmployeeID;
        private string _Name = string.Empty;
        private int _DepartmentID;
        private double _Salary;

        public int EmployeeID { get { return _EmployeeID; } set { _EmployeeID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public int DepartmentID { get { return _DepartmentID; } set { _DepartmentID = value; } }
        public double Salary { get { return _Salary; } set { if (value > 0) _Salary = value; } }

        public EmployeeClass() { }

        public EmployeeClass(int EmployeeId, string Name)
        {
            this.EmployeeID = EmployeeId;
            this.Name = Name;
        }
        public EmployeeClass(int EmployeeId, string Name, int DepartmentID, double salary)
        {
            this.EmployeeID = EmployeeId;
            this.Name = Name;
            this.DepartmentID = DepartmentID;
            this.Salary = salary;
        }
        public static List<EmployeeClass> AddEmployeeToList()
        {
            List<EmployeeClass> EmployeeList = new List<EmployeeClass>()
            { new EmployeeClass(Id++, "Rana Raj",1101 , 40000),
              new EmployeeClass(Id++, "Vadher Raj",1101 , 35000),
              new EmployeeClass(Id++,"Parmar Rakesh",1102,20000),
              new EmployeeClass(Id++,"Vadhela Yashraj",1103,25000),
              new EmployeeClass(Id++,"Ahsish Pateliya",1101,40000),
              new EmployeeClass(Id++,"Man Bhadhareshiya",1104,35000),
              new EmployeeClass(Id++,"Megh Mevad",1102,20000),
              new EmployeeClass(Id++,"Aayush Panchasara",1104,25000),
              new EmployeeClass(Id++,"Parajapati Kishan",1102,20000),
              new EmployeeClass(Id++,"Vaghela Jatin",1101,40000),
              new EmployeeClass(Id++,"Harsh Jadav",1105,42000),
              new EmployeeClass(Id++,"Parth Patel", 1105, 42000),
              new EmployeeClass(Id++,"Dhrasti Kumar",1101,40000),
              new EmployeeClass(Id++,"Patel Raj",1102,20000),
              new EmployeeClass(Id++,"Purohit Priyank",1101,40000),
              new EmployeeClass(Id++,"Het Solanki",1103,25000),
              new EmployeeClass(Id++,"Hansil Chapadiya",1101,40000),
              new EmployeeClass(Id++,"Kiran Mehta",1103,25000),
              new EmployeeClass(Id++,"Pradeep Patel",1101,40000)
            };



            return EmployeeList;
        }

    }
}
