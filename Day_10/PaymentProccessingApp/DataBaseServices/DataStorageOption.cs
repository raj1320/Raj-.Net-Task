using System;
using System.Collections.Generic;
using System.Text;
using PaymentProccessingApp.UserModule;
namespace PaymentProccessingApp.DataBaseServices
{
    internal interface DataStorageOption
    {

        void StoreDatavaluesToDatabase(User user);
        void PrintDataStoreValue();

        void PrintDataStoreValueOfUser(User user);
        // many more methods....

        public void storecashEmail(string email, string password);

        public bool isEmialMatchWithpass(string email, string password);

        public User FindUser(string email);
    }
}
