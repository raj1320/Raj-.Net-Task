using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndMethodOverriding.EmployeeTask
{
    internal class FullTimeEmployee : Employee
    {
        // Both base and derived class parameterized constructor calling
        public FullTimeEmployee(string Name,string Occupation,string Address,double BaseSalary,double TottalAllowance,double Tax) : base(Name, Occupation, Address)
        {
           this.BaseSalary = BaseSalary;
           this.TottalAllowance = TottalAllowance;   
           this.Tax = Tax;

        }

        // Calculating Salary for fulltime employee
        public override double  CalculateSalary()
        {
            Salary = BaseSalary + TottalAllowance - Tax;
            return Salary;
        }

        // Display Fields
        public override void Display()
        {
            Console.WriteLine($"\nHere is the Complete Detail of FullTime Employeee has an EID {EID}");

            Console.WriteLine("Name              : " +Name);
            Console.WriteLine("Occupation        : "+Occupation);
            Console.WriteLine("Address           : "+Address);
            Console.WriteLine("Base Salary       : " + BaseSalary + " Rupess/Month");
            Console.WriteLine("Tottal Allowance  : " + TottalAllowance + " Rupess/Month");
            Console.WriteLine("Deducted Tax      : " + Tax + " Rupess/Month");
            Console.WriteLine("Total Salary      : " + Salary + " Rupess");


        }
    }
}
