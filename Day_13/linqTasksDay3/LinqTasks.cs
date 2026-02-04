///<summary>
/// Mostly using Method syntax , also using query syntax for perform joins operation easily.
/// </summary>

using linqTasks3;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace linqTasksDay3
{
    internal class LinqTasks
    {
        static void Main()
        {

            var ListOfEmplooyees = EmployeeClass.AddEmployeeToList();
            var ListOfDepartment = DepartmentClass.AddDepartmentToList();
            var ListOfOrder = OrderClass.AddOrderToList();
            var ListOfStudent = StudentClass.AddStudentsToList();

            Console.WriteLine("==================================================================================================================\n");
           
            #region TASK1

            Console.WriteLine("---------------------------------------------------------->Task1<--------------------------------------------------\n");
                            var Result1 = ListOfEmplooyees.Where(x => x.Salary > 30000).
                                Select(
                                y => new
                                {
                                    EmployeeID = y.EmployeeID,
                                    EmployeeName = y.Name,
                                    EmployeeSalary=y.Salary,
                                    EmployeeDepartmentID = y.DepartmentID
                                });

                            ListOfEmplooyees.Add(new EmployeeClass(EmployeeClass.Id++, "Madhav", DepartmentClass.DeptIDSalut, 50000));


                            foreach(var result in Result1)
                            {
                                Console.WriteLine(result);
                            }

            // Theory :-
            //         Here i am observing Deferred Execution because when i am executing foreach loop then only the iteration
            //         happens of linq query , so when we will explisitly mention the ToList() method then it returns actual concrete list
            //         by enforcing immediate execution and while i am iterating on it then it print the concrete list result rather iterating on actual list ListOfEmployees...
            //         so this is default  behaviour of any linq query
            //         now if i am adding  a new object in my list and if it follows a where condition then it will come to the output 
            //         even i write it after a query result assignment so ,that is what actual extract of Deferred execution behaviour.

            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK2

            Console.WriteLine("---------------------------------------------------------->Task2<--------------------------------------------------\n");

                    var Result2 = ListOfStudent.Where(x => x.Marks > 40).
                                Select(y =>
                                new { 
                                    Name=y.Name,
                                    RollNumber=y.RollNo,
                                    Marks=y.Marks
                                }
                                ).ToList();

                            StudentClass obj = ListOfStudent[2];
                            obj.Marks = 41;

                            foreach (var item in Result2)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("\n================================\n");

                            var Result02 = ListOfStudent.Where(x => x.Marks > 40).
                               Select(y =>
                               new {
                                   Name = y.Name,
                                   RollNumber = y.RollNo,
                                   Marks = y.Marks
                               }
                               ).ToList();

                            foreach (var item in Result02)
                            {
                                Console.WriteLine(item);
                            }

            // Theory :-
            //         Here i am observing immediate Execution because  when we will explisitly mention the ToList() method then it returns a  concrete list
            //         by enforcing immediate execution and while i am iterating on it then it print the concrete list result rather iterating on actual list ListOfEmployees...
            //         
            //         now if i am adding  a new object in my list and if it follows a where condition then it will not come to the output 
            //         that is what actual extract of Immediate execution behaviour.
            //
            //         Basic diffrence :
            //
            //        Deferred Execution :-
            //
            //                  - Linq queries like where(),slect(),OrderBy() return an IEnumerable/IQueryable
            //                   that represents the query , not the actual result
            //                  - The query is not executed immediately it executed after you iterate on a loop
            //                   If data change before iteration , the new data also consider in query.
            //
            //        Immediate Execution:-
            //
            //                  - When we calling methods like .ToList(),.ToArray(),.Count(),.First(),.Max() etc are
            //                   executed the query right away
            //                  - Result materialized into a concreate collection.
            //                   If data change before iteration , the new data is not consider in query.         


            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK3

                    Console.WriteLine("---------------------------------------------------------->Task3<--------------------------------------------------\n");


                    var Result3 = ListOfOrder.SelectMany(x => x.ListOfOrderItem).Select(y=>new {ProductName=y.ProductName});

                    foreach(var  item in Result3)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Here is the total count of product which is sold: " + Result3.Count());


            // Theory :- i used SelectMany method first beacsue my order list contains further list of orderItem which is not directly excessible
            //           thats why i am using this method, now i get flatten result from the query and the second method 'select' i am using for selecting 
            //           ProductName from the result.
            //           In first Console i am using only count which return total count by considering reapeted values as well. 


            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK4

            Console.WriteLine("---------------------------------------------------------->Task4<--------------------------------------------------\n");

                    var Result4 = from E in ListOfEmplooyees
                                  join D in ListOfDepartment
                                  on E.DepartmentID equals D.DepartmentID
                                  group E by D.DepartmentName into g
                                  select new
                                  {
                                      g.Key,
                                      Count=g.Count()
                              
                                  };

                                  foreach(var item in Result4)
                                  {
                                        Console.WriteLine(item);
                                  }




            // Theory :- Here i am using deferred type beacuse it will not execute query until enumeration 
            //           perform on it so while enumerating the query it will execute the groupby and count apply
            //           only when we perform enumeration .
            //           if we define ToList() , ToDictionary() etc behind the result by materializes  it and perform immediate execution

            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK5


            Console.WriteLine("---------------------------------------------------------->Task5<--------------------------------------------------\n");

                    var Result5 = ListOfEmplooyees.AsEnumerable().Where(E => E.Salary > 30000).Select(E => new { EmployeeName=E.Name,EmployeeSalary= E.Salary,EmployeeDepartmentID= E.DepartmentID });

                    Console.WriteLine("\nHere is the Enumerable method call..\n");

                    foreach (var item in Result5)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine("\nHere is the Queryable method call..\n");

                    var Result05 = ListOfEmplooyees.AsQueryable().Where(E => E.Salary > 30000).Select(E => new { EmployeeName = E.Name, EmployeeSalary = E.Salary, EmployeeDepartmentID = E.DepartmentID });

                    foreach (var item in Result05)
                    {
                        Console.WriteLine(item);
                    }


            // Theory :-
            //           Here i am using AsEnumerable in first query and then linq-to-object translation occurs in memory only
            //           And in second query i am using AsQueryable it translate linq-to-sql query syntax if we query on data base 
            //           but in our case it only runs inside the memory beacause list is present in side a memory
            //           
            //           This is a basic difference between Enumerable and Queryable also
            //           -Enumerable execute query in side a memory only and return concreate result
            //            whether Queryable only translate the linq query to SQL query and run it to the db
            //           -Enumerable use delegate for internal working and Querable use expression tree to translate the linq to sql


            Console.WriteLine("===================================================================================================================\n");


            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK6

            Console.WriteLine("---------------------------------------------------------->Task6<--------------------------------------------------\n");

            var Result6 = ListOfEmplooyees.AsQueryable().Select(E => new { EmployeeName = E.Name,E.DepartmentID }).ToList();

            foreach(var item in Result6)
            {
                var Result06 = ListOfDepartment.AsQueryable().FirstOrDefault(D => D.DepartmentID == item.DepartmentID);
                Console.WriteLine($"EmployeeName = {item.EmployeeName} , DepartmentName = {Result06?.DepartmentName}");
            }

            Console.WriteLine("After removing N+1 problem \n");


            var Result_6 = ListOfEmplooyees.AsQueryable().Join(
                ListOfDepartment,
                E=>E.DepartmentID,
                D=>D.DepartmentID,
                (a,b)=>new {EmployeeName=a.Name,EmployeeDepartment=b.DepartmentName}
                );
            
            foreach (var item in Result_6)
            {
                Console.WriteLine(item);
            }

            // Theory :-  The N+1 query problem happens when our code runs one main query and then fires extra queries for each item.
            //            it's happens when lazy loading is used.
            //            This leads to poor performance because the database gets hit multiple times unnecessarily.
            //            The fix is usually eager loading with Include or smart projections to fetch everything in one go.
            //
            //            here in first case i am using AsQueryable which bascicully converts Linq query to SQL query internully or
            //            we can say enumerable to queryable.so here i am not using any data base record even though it works becasue 
            //            Queryable return an expression interface which runs in memory and use list which is already in memory.
            //            If am using any Db.Table then it will execute in Database only.
            //            It Use Expression tree sytax internally which is derived from given query.
            //
                          

            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK7

            Console.WriteLine("---------------------------------------------------------->Task7<--------------------------------------------------\n");

                    var Result7 = ListOfOrder.SelectMany(x => x.ListOfOrderItem).Select(y => new { ProductName = y.ProductName });

          
                            Console.WriteLine("Here is the total count of product which is sold: " + Result3.Count());

            

                            Console.WriteLine("Here is the total count of Distinct product which is sold: " + Result3.Distinct().Count());

            // Theory :- i used SelectMany method first beacsue my order list contains further list of orderItem which is not directly excessible
            //           thats why i am using this method, now i get flatten result from the query and the second method 'select' i am using for selecting 
            //           ProductName from the result.
            //           In first Console i am using only count which return total count by considering reapeted values as well. 
            //           Here i am also using Distinct and Count both methods symultaniously to get distinct records and then perform count operation on it. 



            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK8

                    Console.WriteLine("---------------------------------------------------------->Task8<--------------------------------------------------\n");

                    var Result8 = ListOfEmplooyees.Select(x=>new {x.EmployeeID,x.Name}).ToDictionary(o => o.EmployeeID,y=>y.Name);
             


                            foreach (var item in Result8)
                            {
                                Console.WriteLine(item);
                            }


            // Theory :-
            //        Here in this Linq query ToDictionary() enforcing the execution of query immediately and return the concreate dictionary 
            //        to the result8 
            //        ToDictionary() accept key and value via lambda expression and set it internally 

            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK9

            Console.WriteLine("---------------------------------------------------------->Task9<--------------------------------------------------\n");

                    var Result9 = ListOfEmplooyees.Where(x => x.DepartmentID == 1101).Select(x=> new {x.Name,x.DepartmentID});


                            foreach (var item in Result9)
                            {
                                Console.WriteLine(item);
                            }

                            var obj2 = ListOfEmplooyees[0];
                            obj2.DepartmentID = 1104;

                            Console.WriteLine("-------------------------------------"); 

                            foreach (var item in Result9)
                            {
                                Console.WriteLine(item);
                            }

            // Theory :- Here i used Where to filtered the data and then perform select operation for selecting fields
            //           Then i Enumerated on result9 and print the result according to the query output
            //           After this i perform certain Modification on acutal list and observed that even if i am not tempering
            //           the result9 variable still in second loop when i further perform Enumeration then i loos the first object
            //           becase it not follows the condition.
            //           So i can conclude that in deferred execution we achive contineous updated result from
            //           Updated List.
            #endregion

            Console.WriteLine("===================================================================================================================\n");

            #region TASK10

            Console.WriteLine("---------------------------------------------------------->Task10<--------------------------------------------------\n");

                    //  When to use ToList()
                    /*
                     *      When we want to enforce the current execution of the query and not wait untill 
                     *      Enumeration process then we can do Materialization of the query result via ToList()
                     *      
                     *      The second most important use case is if we want to reduce computational cost due to deferred execution 
                     *      then by enforcing the execution taken plase for only one time then we can use it.
                     * 
                     *      Also if we perform any modification on actual list, it is not propogated while iteration via foreach loop
                     *      in this kind of situation we can use ToList()
                     *
                     */

                    // Avoid multiple enumeration
                    /* 
                    * 
                    * 
                    *  if we enumerated the same deferred query each time it will re-executed each time 
                    *  which will increase the overhaed.
                    *  
                    *  so that's why before enumerating multiple time we can use .ToList() or .ToDicionary() whaterver
                    *  collection you want. 
                    *  
                    *  This action not re-executing query each time rather inforcing execution once and return the result
                    *  we can perform further linq operation on result.
                    * 
                    * 
                    */


                    //Use Any() instead of Count() > 0
                    /*
                     * we can use Any() instead of Count() because Any() return when it founds one true result
                     * and Count filter the entire list until it reach at end 
                     *
                     * we can use Ayn() when we want at least one condtion is satisfiled and it run with O(1) complexity
                     * In case of Count() it runs throughout the list or dataset (upto n) and takes o(n) to run
                     * 
                     * so complexity wise also Any() is better.
                     * 
                     */

                    //Avoid loops if LINQ is possible
                    /*
                     *  Linq provides lots of things then Loop 
                     *  first is 1) redability :- one can easily understand the complex logic wrote in LINQ rather than LOOP
                     *  second is 2) Composability :- we can perform multiple query chaining and reduce the complex logic into the simple one
                     *  third is 3) Less Erro Prone :- because loop required counters , accumulator or condition etc.
                     *  four is 4) Boiler code :- Here in Linq we don't need to write any boiler  plate code like counter variable , looping condition and
                     *                            any other looping variable.
                     */

                    //N+1 query problem
                    /*
                     *  The N+1 query problem happens when our code runs one main query and then fires extra queries for each item.
                     *  it's happens when lazy loading is used.
                     *  This leads to poor performance because the database gets hit multiple times unnecessarily.
                     *  The fix is usually eager loading with Include or smart projections to fetch everything in one go.
                     *            
                     *  for an example
                     *            
                     *            var author = Context.Authors.ToList(); first query
                     *             
                     *            foreach(var author in authors)
                     *            {
                     *                 var books = author.Books.ToList(); // N queries run
                     *            }
                     *            
                     *            
                     *            resolve N+1 query
                     *            
                     *            var author = Context.Author
                     *                                .Include(B=>B.Books)
                     *                                .ToList();
                     *                                
                     * No need to separately perform lazy loading used  Eager Loading
                     */




            #endregion

            Console.WriteLine("===================================================================================================================\n");

        }
    }
}
