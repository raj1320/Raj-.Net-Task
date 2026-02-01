/// <summary>
/// 
///  AuthenticateUserUtility responsible for Performing operation on DBservice and User Module , also Use Notifcation Module Effisiently..
///  Having 3 Major Function 
///  1) Registration :- store User Data in User Module List...
///  2) Login :- Perform Login Operation By checking Email and Password in EmailPassword Cash Discionary
///              After Validating it provides Token to the User for Logout...
///  3) Logout :- It Validate client Token with given Token.
/// 
/// According to the SOLID Principle,D=> DIP indicates that (Dependency Inversion Principle) 
/// Prinlicple say's That Higer Level Module is Not depends on Lower Lelel Module instead both deepends on abstraction.
/// 
/// So here Higher Level Module is AuthenticateUserUtility service and lowerLevel Module is DataBaseConnectionAndServices
/// so here rather depends on Lower level i use DataStorageOption interface which reduce the dependancy and inverse it to the abstraction.
/// 
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PaymentProccessingApp.UserModule;
using PaymentProccessingApp.DataBaseServices;
using PaymentProccessingApp.NotificationModule;
namespace PaymentProccessingApp.AuthenticationModule
{
    internal class AuthenticateUserUtility
    {
        public int token;
        DataStorageOption DBservice;

        public AuthenticateUserUtility(DataStorageOption DBservice)
        {
            this.DBservice = DBservice;
        }
       
        public User Register(string Name,string Email,long Phone,string Password,List<BankDetails> Banklist, List<UPIDetails> UPIDlist)
        {
            try
            {
                User newUser = new User();
                newUser.Name = Name;
                newUser.Email = Email;
                newUser.Phone = Phone;
                newUser.Password = Password;
                newUser.ListOfBankDetails = Banklist;
                newUser.ListOfUPIDetails = UPIDlist;

                DBservice.storecashEmail(Email,Password);
                DBservice.StoreDatavaluesToDatabase(newUser);
                Console.WriteLine("User Saved Successfully");
                return newUser;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int Login(string email,string password)
        {
            try {

                if (DBservice.isEmialMatchWithpass(email, password))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Login Successfully....");
                    Random randomTokenGen = new Random();
                    token = randomTokenGen.Next(1200000, 6700000);
                    INotification notification = new EmailNotification(email);
                    notification.Notify($"\nThis is Your Token {token} please store it and use for logout \n");
                    return 1;
                }
                else
                {
                    throw new Exception("Email or Password Does Not Match\n Login Fails.....");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);   
            }
           
            return 0; 
            
        }

        public int logout(int tokenByClient)
        {
            if (tokenByClient != this.token)
            {
                Console.WriteLine("\nToken is Not valid...\n");
                return 1;
            }
            else
            {
                Console.WriteLine("\nLogout Successfully...\n");
                return 0;
            }
        }
            
      }


    
}
