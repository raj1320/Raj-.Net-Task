/// <summary>
///  It is a Data Base connectivityn & Service  Class which implements the  DataStorageOption interface
/// </summary>




using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.DataBaseServices
{
    internal class StoreAtLocalStore : DataStorageOption
    {
       public static List<User> listOfUser = new List<User>();
       public static Dictionary<string, string> listOfEmailPassword = new Dictionary<string, string>();

        public void StoreDatavaluesToDatabase(User user)
        {
            Console.WriteLine("Data saving Mode...");
            Thread.Sleep(1000);
            listOfUser.Add(user);
            Console.WriteLine("\nData saved Successfully");
        }

        public void PrintDataStoreValue()
        {
            //if(listOfUser.Count() <= 0) { Console.WriteLine("List is Empty...");return; }
            Console.WriteLine("\n Here is the List of Registered Users");
            foreach (User user in listOfUser)
            {
                Console.WriteLine("\n");

                Console.WriteLine($"Name of the User is              : {user.Name}");
                Console.WriteLine($"Email of the User is             : {user.Email}");
                Console.WriteLine($"Phone Number of the User is      : {user.Phone}");

                foreach(BankDetails Obj in user.ListOfBankDetails)
                {
                     Console.WriteLine($"Bank Name of the User is         : {Obj.BankName}");
                     Console.WriteLine($"Bank Branch Name of the User is  : {Obj.BanchName}");
                     Console.WriteLine($"Bank Balance of the User is      : {Obj.Balance}");
                    
                }

                foreach (UPIDetails Obj in user.ListOfUPIDetails )
                {
                    Console.WriteLine($"UPI ID of the User is            : {Obj.UPIId}");
                    Console.WriteLine($"Bank Balance of the User is      : {Obj.Balance}");
                }


                Console.WriteLine("\n\n");
            }

        }

        public void PrintDataStoreValueOfUser(User user)
        {
            //if (listOfUser.Count() <= 0) { Console.WriteLine("User  not Registered..");return; }
            Console.WriteLine("\nHere is the List of Current User");
            Console.WriteLine("\n");

            Console.WriteLine($"Name of the User is              : {user.Name}");
            Console.WriteLine($"Email of the User is             : {user.Email}");
            Console.WriteLine($"Phone Number of the User is      : {user.Phone}");

            foreach (BankDetails Obj in user.ListOfBankDetails)
            {
                Console.WriteLine($"Bank Name of the User is         : {Obj.BankName}");
                Console.WriteLine($"Bank Branch Name of the User is  : {Obj.BanchName}");
                Console.WriteLine($"Bank Balance of the User is      : {Obj.Balance}");

            }

            foreach (UPIDetails Obj in user.ListOfUPIDetails)
            {
                Console.WriteLine($"UPI ID of the User is            : {Obj.UPIId}");
                Console.WriteLine($"Bank Balance of the User is      : {Obj.Balance}");
            }


            Console.WriteLine("\n");

        }

        public void storecashEmail(string email, string password)
        {
            Console.WriteLine("******************");
            listOfEmailPassword.Add(email, password);
        }

        public bool isEmialMatchWithpass(string email, string password)
        {
            foreach (KeyValuePair<string, string> keyValue in listOfEmailPassword)
            {
                if (keyValue.Key == email && keyValue.Value == password) return true;
            }
            Console.WriteLine("Not store..");
            
            return false;
        }

        public User FindUser(string email)
        {
            User user= new User();
            foreach(User u in listOfUser)
            {
                if(u.Email == email)
                {
                    user = u;
                    break;
                }
            }
            return user;
        }
    }

}
