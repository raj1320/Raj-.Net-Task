using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndMethodOverriding.EmployeeTask
{
    internal class ContractEmployee : Employee
    {
        // Both base and derived class parameterized constructor calling
        public ContractEmployee(string Name, string Occupation, string Address, double BaseSalary,double Houers) : base(Name, Occupation, Address)
        {
            this.BaseSalary = BaseSalary;
            this.Houers= Houers;

        }

        // Calculating Salary for Contract employee
        public override double CalculateSalary()
        {
            Salary = BaseSalary * Houers;
            return Salary;
        }
        
        // Display fields
        public override void Display()
        {
            Console.WriteLine($"\nHere is the Complete Detail of FullTime Employeee has an EID {EID}");

            Console.WriteLine("Name                           : " + Name);
            Console.WriteLine("Occupation                     : " + Occupation);
            Console.WriteLine("Address                        : " + Address);
            Console.WriteLine("Base Salary                    : " + BaseSalary + " Rupess/Houers");
            Console.WriteLine("Tottal Houers of Working       : " + Houers + " Houers");
            Console.WriteLine("Tottal Salary                  : " + Salary + " Rupess");

        }
    }
}
