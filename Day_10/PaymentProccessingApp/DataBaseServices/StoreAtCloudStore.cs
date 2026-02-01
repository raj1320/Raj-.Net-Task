/// <summary>
///  It is a Data Base connectivityn & Service  Class which implements the  DataStorageOption interface
///  It does not completed yest hence i don't have proper idea to implement cloud base logic...
///  So majorly i called StoreAtLocalStorgae class for DataStorageOption
/// </summary>

using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.DataBaseServices
{
    internal class StoreAtCloudStore : DataStorageOption
    {
       public  void StoreDatavaluesToDatabase(User user)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Data Send to through the API...");
            Console.WriteLine("Data saved Successfully");
        }
        public  void PrintDataStoreValue()
        {
            // Data is fetch from database and display it...
        }

        public void PrintDataStoreValueOfUser(User user)
        {
            // Individual data printed...
        }

        public void storecashEmail(string email, string password)
        {
            // store in dictionary..
        }
        // many more methods....

        public bool isEmialMatchWithpass(string email, string password)
        {
            // check the email and password..
            return false;
        }

        public User FindUser(string email)
        {
            User user = new User();
            // retrun after find...
            return user;
        }
    }
}
