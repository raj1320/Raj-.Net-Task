///<summary>
/// Using Query syntax for each task , also comment some method syntax code
/// </summary>


using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace LinqTasksDay2
{
    internal class LinqTasks
    {
        static void Main()
        {
            List<EmployeeClass> EmployeeList = EmployeeClass.AddEmployeeToList();
            List<DepartmentClass> DepartmentList = DepartmentClass.AddDepartmentToList();

Console.WriteLine("====================================================================================================\n");

            #region TASK1


                    Console.WriteLine("---------------------------------------------> Task 1 <---------------------------------------------\n");

                    var MaxSalary = EmployeeList.Max(x => x.Salary);
                    var MinSalary = EmployeeList.Min(x => x.Salary);
                    var TotalSalary = EmployeeList.Sum(x => x.Salary);
                    var AvrageSalary = EmployeeList.Average(x=> x.Salary);

                    Console.WriteLine($"\n Here is The Max Salary is : {MaxSalary} \n Here is The Min Salary is : {MinSalary}\n Here is The Total Salary is : {TotalSalary} \n Here is The Avarage Salary is : {AvrageSalary}" );

            
                    Console.WriteLine("----------------------------------------------------------------------------");


                    var CountInEachDepartment = from E in EmployeeList
                                                join D in DepartmentList
                                                on E.DepartmentID equals D.DepartmentID
                                                group D by D.DepartmentName into g
                                                select new
                                                {
                                                    departmentName =g.Key,
                                                    count = g.Count()
                                                };



                    foreach ( var result in CountInEachDepartment)
                    Console.WriteLine(result);


            //Theory :-
            //          Here i am using Max, Min, Sum & Averag Aggregation method which is very helpfull to find out the
            //          Arithmatic properties of an atribute(in terms of Data Base) it 
            //          According to my study it applies Accumulator function in repeated sequence
            //      
            //          It works on IEnumerator
            //          it cummultetively run result = Func(result,nextElement)
            //          
            //          Sum:- It maintains running total
            //          Count:- Increments a counter per element
            //          Max:- It Track the largest so far
            //          Min:- It track the smallest so far 
            //          Average:- It perform sum and count both and return a result by divides

            // So , that is why i used Sum,count,max & Average

            #endregion

Console.WriteLine("====================================================================================================\n");

            #region TASK2



                    Console.WriteLine("---------------------------------------------> Task 2 <---------------------------------------------\n");

                    var EmployeeNameandDeptName = from E in EmployeeList
                                                      join D in DepartmentList
                                                      on E.DepartmentID equals D.DepartmentID into Leftjoin
                                                      from D in Leftjoin.DefaultIfEmpty()
                                                      select new
                                                      {
                                                          E.Name,
                                                          D?.DepartmentName
                                                      };
                        foreach (var result in EmployeeNameandDeptName)
                            Console.WriteLine(result);


                        Console.WriteLine("----------------------------------------------------------------------------");


                        var DeptNameAndEmployeeName = from D in DepartmentList
                                                      join E in EmployeeList
                                                      on D.DepartmentID equals E.DepartmentID into Leftjoin
                                                      from E in Leftjoin.DefaultIfEmpty()
                                                      select new
                                                      {
                                                          D.DepartmentName,
                                                          E?.Name
                                                      };
                        foreach (var result in DeptNameAndEmployeeName)
                            Console.WriteLine(result);


                    //var EmployeeNameandDeptNameByMethodSyntax = EmployeeList.GroupJoin(
                    //        DepartmentList,
                    //        a => a.DepartmentID,
                    //        b => b.DepartmentID,
                    //        (c, cgroup) => new { c,cgroup})
                    //        .SelectMany(
                    //         x=> x.cgroup.DefaultIfEmpty(),
                    //        (l, v) => new
                    //        {
                    //           EmployeeName =l.c.Name,
                    //           DapartmentName =v.DepartmentName
                    //        }
                    //        );



            // Theory :-
            //          Here i am using concept of lefjoin where in first block i perform left join to the entire Employee list and department List 
            //          then print Employee Name and if there may be some Employee whoes have not been asign department so there may be possible we have  
            //          Null values over there
            //
            //          Same for second block also Department has a Department Name but there may be some Department may not have Employees whithin it so
            //          we use leftjoin concept to overcome this sitution
            //
            // into  key for first Block:- We use Groupjoin internally 
            //                             and set D in DefaultIfEmpty() to having null values possibally  (In a first Block)

            // into  key for second Block:- We use Groupjoin internally 
            //                             and set E in DefaultIfEmpty() to having null values possibally  (In a second Block)                             

            #endregion

Console.WriteLine("====================================================================================================\n");

            #region TASK3

                    Console.WriteLine("---------------------------------------------> Task 3 <---------------------------------------------\n");


                    var SalaryAndCountByGroupby = from E in EmployeeList
                                                  join D in DepartmentList on E.DepartmentID equals D.DepartmentID
                                                  group E by D.DepartmentName into iresult
                                                  select new
                                                  {
                                                      DepartmentName = iresult.Key,
                                                      AverageSalry = iresult.Sum(emp => emp.Salary),
                                                      EmployeeCount = iresult.Count()
                                                  };


                    //var SalaryAndCountByGroupby2 = EmployeeList.Join(
                    //    DepartmentList,
                    //    E => E.DepartmentID,
                    //    D => D.DepartmentID,
                    //    (x, y) => new
                    //    {
                    //        DepartmentName = y.DepartmentName,
                    //        Salary = x.Salary,
                    //        DepartmentID = y.DepartmentID
                    //    }
                    //    ).GroupBy(y => y.DepartmentName).Select(y => new { y.Key , count=y.Count(),AvgSalary =y.Average(y=>y.Salary)  });


            foreach (var result in SalaryAndCountByGroupby)
                Console.WriteLine(result);

            // Theory :-
            //            Here we use concept of innerjoin and groupby together to get the appropriate result
            //         
            // Join:-     It materialize inner sequence into Lookup<Tkey,TElement> and also perform buffering.
            // group by:- It Partitions a sequence into groups based on a key
            //            Each group is represented by an IGrouping<TKey,TElement>
            //            It use hashing internally.
            //
            //            so first i perform  inner join operation on both list then perform 
            //            grouping operation for each different department from intermediatery result
            //            and print department name , average salary and count

            #endregion

Console.WriteLine("====================================================================================================\n");

            #region TASK4

                    Console.WriteLine("---------------------------------------------> Task 4 <---------------------------------------------\n");


                    var AvgSalary = EmployeeList.Average(y=> y.Salary);
                    Console.WriteLine("\nAverage Salary is:"+AvgSalary+"\n");
                    var SalaryGreaterThenAVG = from E in EmployeeList
                                 where E.Salary > AvgSalary
                                 select new { E.Name, E.Salary };

                    foreach (var result in SalaryGreaterThenAVG )
                        Console.WriteLine(result);



                    Console.WriteLine("---------------------------------------------------");



                    var HRmaxSalary = EmployeeList.Where(e=>e.DepartmentID == 1104 ).Max(y => y.Salary);
                    Console.WriteLine("\nMax salary in HR Department is :" + HRmaxSalary+"\n");
                    var SalaryGreaterThenHR = from E in EmployeeList
                                               where E.Salary > HRmaxSalary
                                               select new { E.Name, E.Salary };

                    foreach (var result in SalaryGreaterThenHR)
                        Console.WriteLine(result);


            // Theory :-
            //           Here i am using both the Method and query syntax to get the solutions of task
            //
            // In a first query,
            // Average:- In a first block i used Average to find out everage salary of employees
            // Where & Select :- Then i apply simple codition check via where and select my disred fields from th where result
            //
            // In a second query,
            // Where and max :- First i need to find out the Which department contains DeptartmentID 1104 which is a id of HR depratment
            //                  so i am using where query , then i need to find maximum salary from that result 
            //                  so i am using Max aggregate method , thats how i got the intermediatery result HRmaxSalary
            // Where and Select :- Here i am first filtering Employee have a salary greaterthan the given HRmaxSalary
            //                     then perform select operation to select Employee name and salary






            #endregion

Console.WriteLine("====================================================================================================\n");

            #region TASK5

                    Console.WriteLine("---------------------------------------------> Task 5 <---------------------------------------------\n");


                    var list1 = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    var list2 = new List<int>{ 2, 4, 6, 8, 10 };

                    var Intersect = list1.Intersect(list2);
                    var Subtract = list1.Except(list2);
                    var Union = list1.Union(list2);

                    Console.WriteLine("Intersect Result....");
                    foreach (var result in Intersect)
                        Console.Write(result+" ");
 
                    Console.WriteLine("\n---------------------------------------------------");

                    Console.WriteLine("Substract Result....");
                    foreach (var result in Subtract)
                        Console.Write(result+" ");

                    Console.WriteLine("\n---------------------------------------------------");

                    Console.WriteLine("Union Result....");
                    foreach (var result in Union)
                        Console.Write(result+" ");


            // Theory :-
            //          Here we have two interger list list1 and list2 
            // Intersect :- It simply means find those value which is common in both the list
            //              and set operation perform same thing.
            // Subtract :- Here i perform Except operation and remove elements of list2 from list1 now list1 contains only those value
            //              which is not present indie list2
            // Union :- here i perform union operation to get unique and all the values from both list
            //
            // All above three follow similer Mechanism which i mention below
            // :- Use a hash based set structure internally.
            // :- Rely on equality comparison use Equals & GetHashCode or a custom comparer.
            // :- Have deferred execution, but buffer data as needed
            #endregion

Console.WriteLine("\n====================================================================================================\n");



        }


    }
}
