///<summary>
/// Here i define EmployeeClass with 5 private fields 
/// And one static method Called AddEmployeeToList which adds dummy data to list and returns Employee List.
/// </summary>


using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTasks
{
    internal class EmployeeClass
    {
        static int Id = 10000;
        
        private int _EmployeeID;
        private string _Name= string.Empty;
        private string _Department= string.Empty;
        private double _Salary;
        private string _City;
        public int EmployeeID {  get { return _EmployeeID; } set { _EmployeeID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Department { get { return _Department; } set { _Department = value; } }
        public double Salary { get { return _Salary; } set { if (value > 0) _Salary = value; } }

        public string City { get { return _City; }set { _City=value; }  }
        public EmployeeClass() { }
        public EmployeeClass(int EmployeeId,string Name,string Department,double salary,string city)
        {
            this.EmployeeID = EmployeeId;
            this.Name = Name;
            this.Department = Department;
            this.Salary = salary;
            this.City = city;
        }
        public static List<EmployeeClass> AddEmployeeToList()
        {
            List<EmployeeClass> EmployeeList = new List<EmployeeClass>() 
            { new EmployeeClass(Id++, "Rana Raj", "IT", 40000,"Khambhat"),
              new EmployeeClass(Id++, "Vadher Raj", "IT", 35000,"Sutrapada"),
              new EmployeeClass(Id++,"Parmar Rakesh","Marketing",20000,"Vadhvan"),
              new EmployeeClass(Id++,"Vadhela Yashraj","Sales",25000,"Gondal"),
              new EmployeeClass(Id++,"Ahsish Pateliya","IT",40000,"Ahmedabad"),
              new EmployeeClass(Id++,"Man Bhadhareshiya","Production",25000,"Surat"),
              new EmployeeClass(Id++,"Megh Mevad","Marketing",20000,"Ahmedabad"),
              new EmployeeClass(Id++,"Aayush Panchasara","Production",25000,"Surat"),
              new EmployeeClass(Id++,"Parajapati Kishan","Marketing",20000,"Amreli"),
              new EmployeeClass(Id++,"Vaghela Jatin","IT",40000,"Kheda"),
              new EmployeeClass(Id++,"Harsh Jadav","Data Analysis",42000,"Vapi"),
              new EmployeeClass(Id++,"Parth Patel", "Data Analysis", 42000,"Nadiyad"),
              new EmployeeClass(Id++,"Dhrasti Kumar","IT",40000,"Anand"),
              new EmployeeClass(Id++,"Patel Raj","Marketing",20000,"Ahmedabad"),
              new EmployeeClass(Id++,"Purohit Priyank","IT",40000,"Somnath"),
              new EmployeeClass(Id++,"Het Solanki","Sales",25000,"Maheshana"),
              new EmployeeClass(Id++,"Hansil Chapadiya","IT",40000,"Anand"),
              new EmployeeClass(Id++,"Kiran Mehta","Sales",25000,"Navsari"),
              new EmployeeClass(Id++,"Pradeep Patel","IT",40000,"Anand")
            };

       
            
            return EmployeeList;
        }

    }
}
