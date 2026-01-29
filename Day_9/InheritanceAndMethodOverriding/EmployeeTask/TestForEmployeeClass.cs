using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace InheritanceAndMethodOverriding.EmployeeTask
{
    internal class TestForEmployeeClass
    {
        static void Main()
        {
            // Using anonymous Object passing Constructor arguments
            var EmployeeDetail = new { Name="Raj", Occupation=".Net Developer", Address="Khambhat" , BaseSalary=35000, TottalAllowance=15000, Tax=2000 };
            Employee employee= new FullTimeEmployee(
                EmployeeDetail.Name,
                EmployeeDetail.Occupation,
                EmployeeDetail.Address,
                EmployeeDetail.BaseSalary,
                EmployeeDetail.TottalAllowance,
                EmployeeDetail.Tax
             );

            // Calculate Salary & Display Fields
            employee.CalculateSalary();
            employee.Display();

            Console.WriteLine("=============================================================");

            // Using anonymous Object passing Constructor arguments
            var EmployeeDetail2 = new { Name = "Ravi", Occupation = "Java Developer", Address = "Somanath", BaseSalary = 5000, Houers=35 };
            Employee employee2= new ContractEmployee(
               EmployeeDetail2.Name,
               EmployeeDetail2.Occupation,
               EmployeeDetail2.Address,
               EmployeeDetail2.BaseSalary,
               EmployeeDetail2.Houers
            );

            // Calculate Salary & Display Fields
            employee2.CalculateSalary();
            employee2.Display();

            Console.WriteLine("=============================================================");
        }
    }
}
