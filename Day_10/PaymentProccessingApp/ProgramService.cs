/// <summary>
/// 
///  This is a main file in which i covered working of  Module
///  it wroks on Regisration , Login , Print Current user Profile , List Of registared User , Logout.
///  
///  There are 3 Major static Object i created 
///  
///             1) AuthService from AuthenticateUserUtility followed by Auth Module
///             2) DBservice from DataBaseConnectionAndServices follwoed by DataBase Service Module
///             3) User from User from User Module
///             
///   Registartion case contain 2 anonymous function to get the repeated data from User , and One general input block
///                It store the Data into Registered UserList
///   
///   Login case contain Login related functionality and it gives token for logout operation
///   
///   Prints User and Users List  , display the CurrentUser and User List
///   
///   Logout Module call the AuthService Logout funtion which match the input token and allow to logout...
/// 
/// 
///   IsLoggin is used for cheking whether the user is loggin currently or not.
///  
///   flag and choice is works for Manage while loop iteration and swith cases..
///   
///   Here i am Covering The principle Called SINGLE RESPONSIBILITY from (SOLID) principle....
///   
///   Each Module is work for only one single responsibility.... 
///   
/// </summary>>

using System;
using System.Collections.Generic;
using System.Text;
using PaymentProccessingApp.AuthenticationModule;
using PaymentProccessingApp.DataBaseServices;
using PaymentProccessingApp.PaymentProcessingModule;
using PaymentProccessingApp.UserModule;
namespace PaymentProccessingApp
{
   
    internal class ProgramService
    {
        static int IsLoggin = 0;
        static int flag = 0;
        static int choice = 0;
        public static User CurrentUser = new User();
        public static DataBaseConnectionAndServices DBservice = new DataBaseConnectionAndServices(new StoreAtLocalStore());
        public static AuthenticateUserUtility AuthService = new AuthenticateUserUtility(new StoreAtLocalStore());
        public static List<BankDetails> Banklist = new List<BankDetails>();
        public static List<UPIDetails> Upilist = new List<UPIDetails>();
        public static void ForINtMemoryAllocation_Validation(ref int Num, string msg)
        {
            string? userInput;
            Console.WriteLine($"{msg} ");
            userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
        }
        public static void ForDoubleMemoryAllocation_Validation(ref double Num, string msg)
        {
            string? userInput;
            Console.WriteLine($"{msg} ");
            userInput = Console.ReadLine();
            if (!double.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
        }
        public static void ForLongMemoryAllocation_Validation(ref long Num, string msg)
        {
            string? userInput;
            Console.WriteLine($"{msg} ");
            userInput = Console.ReadLine();
            if (!long.TryParse(userInput, out Num)) Console.WriteLine("Provide appropriate input");
        }


        public static void RegisterUserCase()
        {
            if (IsLoggin == 1) { Console.WriteLine("Please Logout first for new Registration..."); return; }
                var GetBankDetailsAndSaveIt = () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter BankName : ");
                    string BankName = Console.ReadLine() ?? "UserBankName";
                    Console.WriteLine();
                    Console.WriteLine("Enter BranchName : ");
                    string BranchName = Console.ReadLine() ?? "UserBankName";
                    Console.WriteLine();
                    Console.WriteLine("Enter IFSCCODE : ");
                    string IFCCODE = Console.ReadLine() ?? "UserBankName";
                    Console.WriteLine();
                    long AccNum = 0;
                    ForLongMemoryAllocation_Validation(ref AccNum, "Enter Account Number:");
                    Console.WriteLine();
                    int PIN = 0;
                    ForINtMemoryAllocation_Validation(ref PIN, "Enter PIN for BankAccount:");
                    Console.WriteLine();
                    double Balance = 0;
                    ForDoubleMemoryAllocation_Validation(ref Balance, "Enter Balance");
                    BankDetails bankDetails = new BankDetails();
                    bankDetails.BankName = BankName.Trim() ?? "UserBankName";
                    bankDetails.BanchName = BranchName.Trim() ?? "UserBanchName";
                    bankDetails.AccNum = AccNum;
                    bankDetails.IFSCCODE = IFCCODE.Trim() ?? "UserBankIFSCCODE";
                    bankDetails.PIN = PIN;
                    bankDetails.Balance = Balance;

                    Banklist.Add(bankDetails);
                };
              
                var GetUPIDetailsAndSaveIt = () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter UPIID : ");
                    string UPIID = Console.ReadLine() ?? "UserUPIID";
                    Console.WriteLine();
                    int UPIN = 0;
                    ForINtMemoryAllocation_Validation(ref UPIN, "Enter PIN for UPI:");
                    Console.WriteLine();
                    double Balance = 0;
                    ForDoubleMemoryAllocation_Validation(ref Balance, "Enter Balance");
                    UPIDetails UpiDetails = new UPIDetails();
                    UpiDetails.UPIId = UPIID.Trim();
                    UpiDetails.UPIPIN = UPIN;
                    UpiDetails.Balance = Balance;
                    Upilist.Add(UpiDetails);
                };

                        Console.WriteLine("Enter Name : ");
                        string Name = Console.ReadLine() ?? "UserName" ;
                        Console.WriteLine();
                        Console.WriteLine("Enter Email : ");
                        string Email = Console.ReadLine() ?? "UserEmail";
                        Console.WriteLine();
                        Console.WriteLine("Enter Password : ");
                        string Password = Console.ReadLine() ?? "UserPassword";
                        Console.WriteLine();
                        long Phone = 0;
                        ForLongMemoryAllocation_Validation(ref Phone, "Enter Phone Number:");


                GetBankDetailsAndSaveIt();

                        string input = "y";
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more Banks..");
                        input = Console.ReadLine() ?? "n";

                        while (input != "n")
                        {
                            GetBankDetailsAndSaveIt();
                            Console.WriteLine("Would you like to add more Banks..");
                            input = Console.ReadLine() ?? "n";
                        }
                
               GetUPIDetailsAndSaveIt();
                
                        input = "y";
                        Console.WriteLine("Would you like to add more UPI..");
                        input = Console.ReadLine() ?? "n";
                        while (input != "n")
                        {
                            GetUPIDetailsAndSaveIt();
                            Console.WriteLine("Would you like to add more Banks..");
                            input = Console.ReadLine() ?? "n";
                        }

               CurrentUser = AuthService.Register(Name, Email, Phone, Password, Banklist, Upilist);
               if (CurrentUser==null) { Console.WriteLine("User Not Login"); return; }
               IsLoggin = AuthService.Login(Email,Password);
        }


        public static void LogginUserCase()
        {

            if (IsLoggin == 1) { Console.WriteLine("\nYou are already login..\n"); return; }
            Console.WriteLine("Enter Email : ");
            string Email = Console.ReadLine() ?? "UserEmail";
            Console.WriteLine("Enter Password : ");
            string Password = Console.ReadLine() ?? "UserPassword";
            IsLoggin = AuthService.Login(Email, Password);
        }


        public static void PrintUserCase()
        {
            Console.WriteLine("Current user  is : ");
            DBservice.PrintCurrentUser(CurrentUser);
        }


        public static void PaymentProcesssUserCase()
        {
            Console.WriteLine("Enter N for Netbanking Enter U for UPIBanking");
            string input = Console.ReadLine() ?? "n";
            double Amount = 0;
            ForDoubleMemoryAllocation_Validation(ref Amount, "Enter the Amount for Payment");
            if (input.ToLower() == "n")
            {
                NetBankingPaymentProcess newPayment = new NetBankingPaymentProcess();
                newPayment.DoPayment(CurrentUser, CurrentUser.ListOfBankDetails[0].PIN, Amount);
            }
            else
            {
                UPIPaymentProcess newPayment = new UPIPaymentProcess();
                newPayment.PayWithQR(CurrentUser, Amount);

            }
        }


        public static void PrintRegisteredUsersListUserCase()
        {
            DBservice.ShowRegisteredUsersData();
        }


        public static void LogoutUserCase()
        {
            if (IsLoggin == 0) { Console.WriteLine("\nYou are not login..\n"); return; }
            int token = 0;
            ForINtMemoryAllocation_Validation(ref token, "Enter Given Token");
            IsLoggin= AuthService.logout(token);

        }

        static void Main()
        {
           
            while (flag !=1) 
            {
               
                Console.WriteLine("Enter 1 for Register...");
                Console.WriteLine("Enter 2 for Login...");
                Console.WriteLine("Enter 3 for viewing your Profile");
                Console.WriteLine("Enter 4 for Payment");
                Console.WriteLine("Enter 5 for viewing Entire User List");
                Console.WriteLine("Enter 6 for Logout...");
                
                ForINtMemoryAllocation_Validation(ref choice, "Enter Your Desire Case..");
                switch (choice)
                {
                    case 1: RegisterUserCase(); break; 
                    case 2: LogginUserCase(); break;
                        
                    case 3: PrintUserCase(); break;
                        
                    case 4: PaymentProcesssUserCase(); break;
                        
                    case 5: PrintRegisteredUsersListUserCase(); break;
                       
                    case 6: LogoutUserCase(); break;
                        
                    default:
                        {
                            flag = 1;
                            break;
                        }
                }


            }

        }
    }
}
