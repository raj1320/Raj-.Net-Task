using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndMethodOverriding.EmployeeTask
{
    // Basic fields common in each Employee..
    internal abstract class Employee
    {
        public static int IdSault=10000;
        int _EID;
        string _Name=string.Empty;
        string _Occupation=string.Empty;
        string _Address = string.Empty;
        double _Salary;
        public double BaseSalary;
        public double TottalAllowance;
        public double Tax;
        public double Houers;
        public Employee(string Name,string Occuation,string Address)
        {
            _EID=IdSault++;
            this.Name = Name;   
            this.Occupation = Occuation;
            this.Address = Address;
        }
        
        public int EID
        {
            get{ return _EID; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Occupation
        {
            get { return _Occupation; }
            set { _Occupation = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public double Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        // Abstracted Method..
        public abstract double CalculateSalary();

        public abstract void Display();
    }


}
