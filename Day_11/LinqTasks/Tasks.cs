/// <summary>
/// i used Query Syntax for getting output from list.
/// </summary>


using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;


namespace LinqTasks
{
    internal class Tasks
    {
        static void Main()
        {
            List<EmployeeClass> EmployeeList = EmployeeClass.AddEmployeeToList();
            List<StudentClass> StudentList = StudentClass.AddStudentsToList();
            List<OrderClass> OrderList = OrderClass.AddOrderToList();



            #region TASK1

                Console.WriteLine("====================================================================");

                var Result1 = from E in EmployeeList
                              where E.Salary > 25000
                              select new { E.EmployeeID, E.Name, E.Salary };

                foreach (var Employee in Result1)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // Where :- It takes sequence of source and predicate (Func delegate works in backend)
            //        - iterator return iterator, when Ennuminator iterate throughout the source and check predicate for each one 
            //        - Uses deferred execution it means no filtering happens until you iterate.
            //
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using these both:- First i need to filter table on the basis of salary and second i need to select columns from table
                      

            #endregion

            Console.WriteLine("====================================================================");

            #region Task2

                var Result2 = from E in EmployeeList
                              where E.Department.Trim() == "IT"
                              select new { E.Name, E.Salary };

                foreach (var Employee in Result2)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // Where :- It takes sequence of source and predicate (Func delegate works in backend)
            //        - iterator return iterator, when Ennuminator iterate throughout the source and check predicate for each one 
            //        - Uses deferred execution it means no filtering happens until you iterate.
            //
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using these both:- First i need to filter table on the basis of salary and second i need to select columns from table

            #endregion

            Console.WriteLine("====================================================================");

            #region TASK3

                var Result3 = from E in EmployeeList
                              where E.Salary > 30000
                              orderby E.Salary
                              select new { E.EmployeeID, E.Name, E.Salary };


                foreach (var Employee in Result3)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // OrderBy:- When i study the concept of orderby it use buffering, store source in a memory and creating key from given selector
            //           and sorting those key internally.
            // Where :- It takes sequence of source and predicate (Func delegate works in backend)
            //        - iterator return iterator, when Ennuminator iterate throughout the source and check predicate for each one 
            //        - Uses deferred execution it means no filtering happens until you iterate.
            //
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using where , orderby & select:- First i need to filter table on the basis of salary , then i need to sort on the basis of salary again and in last  i need to select columns from table.



            #endregion

            Console.WriteLine("====================================================================");

            #region TASK4

                // i used 'orderby' query for sorting a records according to the Department and Name accordingly
                // And also use 'Select' query for selecting Columns from table 
                var Result4 = from E in EmployeeList
                              orderby E.Department, E.Name
                              select new { E.EmployeeID, E.Name, E.Department };


                foreach (var Employee in Result4)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // OrderBy:- When i study the concept of orderby it use buffering, store source in a memory and creating key from given selector
            //           and sorting those key internally.
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using orderby & select:- First i need to sort on the basis of Department and then Name for each departmentn and in last  i need to select columns from table.


            #endregion

            Console.WriteLine("====================================================================");

            #region TASK5

                var Result5 = from S in StudentList
                              select new { S.Name, S.Marks, Result = S.Marks >= 40 ? "Pass" : "Fail" };

                foreach (var Employee in Result5)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using select :-i need to select columns from student table
            // Over here i used Ternary oparetor and assign the value to new field "result" , it says whether the student is pass or fail
            // Using Ternary Operator is comparitively easy then the if else statement it gives one line condition cheking and assigning 



            #endregion

            Console.WriteLine("====================================================================");

            #region TASK6

               

                var Result6 = from E in EmployeeList
                              select new { Employee_Name = E.Name, Employee_Department = E.Department, Employee_City = E.City };

                foreach (var Employee in Result6)
                {
                    Console.WriteLine(Employee);
                }

            // Theory, 
            // Select :- It takes Sequence oof Source and Use Selector function (here also Func use in backend)
            //         - It is also return iterator for looping..
            //
            // Why i am using select :-i need to select columns from student table
            // i used anonymous types beacuse it's simple to implement i mean no need to write bolier plate code 
            // it prvoides ReadOnly property to the fields which is most suitable as a result of query

            #endregion

            Console.WriteLine("====================================================================");

            #region TASK7

                //var Result7 = from Oc in OrderList
                //              from OI in Oc.ListOfOrderItem
                //              select OI.ProductName;


                var Result7 = OrderList.SelectMany(e => e.ListOfOrderItem).Select(y => y.ProductName);


                foreach (var Employee in Result7)
                {
                    Console.WriteLine(Employee);
                }

            // Theory,
            // SelectMany:- Works by projecting eacch element of a sequence into an inner sequence,
            //              then flatterning all those inner sequences into a single through both the outer and inner collections.
            //              we can say that  it is a syntactic sugar for nested loops that itrate through both the outer and inner collections.

            //              It use to func delegate internally. create collectionSelector object at in side the outer loop
            //              then Produces flattened results one by one (lazy evaluation) and return it as a result.

            // Why i am using anonymous type:- anonymous types beacuse it's simple to implement i mean no need to write bolier plate code 
            // and it prvoides ReadOnly property to the fields which is most suitable as a result of query result.


            #endregion

            Console.WriteLine("====================================================================");

            #region TASK8

            //var Result8 = OrderList.SelectMany(e => e.ListOfOrderItem.Select(y=> new {e.CustomerName,y.ProductName}));

            var Result8 = from OC in OrderList
                              from OI in OC.ListOfOrderItem
                              select new { OC.CustomerName, OI.ProductName };



                foreach (var Order in Result8)
                {
                    Console.WriteLine(Order);
                }

            // Theory,
            // SelectMany:- Works by projecting eacch element of a sequence into an inner sequence,
            //              then flatterning all those inner sequences into a single through both the outer and inner collections.
            //              we can say that  it is a syntactic sugar for nested loops that itrate through both the outer and inner collections.

            //              It use to func delegate internally. create collectionSelector object at in side the outer loop
            //              then Produces flattened results one by one (lazy evaluation) and return it as a result.,
            // Why i am using this technique:- 
            // Here i mention two diffrent approch to check how things work internully in case of using select within selectMany 
            // var Result8 = OrderList.SelectMany(e =>e.ListOfOrderItem.Select(y=>new {e.CustomerName,y.ProductName}));

            // And also defining Query like syntax which is simple to implment and understandable... 
            // using select query to filetr things and also it use selectmany internully because of two from statements



            #endregion

            Console.WriteLine("====================================================================");

            #region TASK9


                var Result9 = (from E in EmployeeList
                               select E.Name).ToList();

                foreach (var Employee in Result9)
                {
                    Console.WriteLine(Employee);
                }

            // Theory :- Here result9 Contains return type static Enumerable class Object
            //           whic convert into List when i use  .ToList() method 


            #endregion

            Console.WriteLine("====================================================================");

            #region TASK10

                var Result0_10 = from E in EmployeeList
                                 where E.Salary >= 20000
                                 select new { E.EmployeeID, E.Name, E.Salary };

                var Result1_10 = EmployeeList.Where(e => e.Salary >= 20000)
                                             .Select(e => new { e.EmployeeID, e.Name, e.Salary });

                Console.WriteLine("Task 10....................");

                Console.WriteLine("Using Query Syntax...");

                foreach (var Employee in Result0_10)
                {
                    Console.WriteLine(Employee);
                }

                Console.WriteLine("Using Method Syntax...");

                foreach (var Employee in Result1_10)
                {
                    Console.WriteLine(Employee);
                }


            // Theory,
            // If we consider Query Syntax :- it gives Readability like SQL Query syntax,
            //                                it gives easiness to study the joins.
            //                                Reduces parentheses clutter compared to deeply nested method calls.
            // If we consider Method Syntax :- it provide eaasiness to chain multiple operations in a pipeline.
            //                                 You can pass complex expressions directly into methods
            //                                 Query syntax autometically convert into Method syntax.

            #endregion

            Console.WriteLine("====================================================================");
        }
    }
}
