/// <summary>
/// It is a Risponsible for DataBase Connection and Services like fetching User and Users Data,
/// It has Save function to save the Value in List 
/// it stricly Follow the OSP principle (Module is Open for Extension and close for Modificaion..)
///  Here i Depends on DataStorageOption Interface so i can scale this service as big as i need
///         I am using Referance of DataStorageOption Interface which get Object a run time and call their object's function accordingly 
///         so o ndeed to check User choose which datastorage Option , what i just need to be known is which mehtos they wants ..
///         I can able to implements that DataStorageOption Interface to many others StorageOption and get contract to define those functionality of DataStorageOption Interface
/// </summary>


using System;
using System.Collections.Generic;
using System.Text;
using PaymentProccessingApp.UserModule;
namespace PaymentProccessingApp.DataBaseServices
{

    internal class DataBaseConnectionAndServices
    {
        DataStorageOption storageOption;
        public DataBaseConnectionAndServices(DataStorageOption storageOption)
        {
            this.storageOption = storageOption;
        }

        public void Save(User user)
        {
            storageOption.StoreDatavaluesToDatabase(user);
        }

        public void ShowRegisteredUsersData()
        {
            this.storageOption.PrintDataStoreValue();
        }

        public void ShowRegisteredUserData()
        {
            this.storageOption.PrintDataStoreValue();
        }
     
        public void PrintCurrentUser(User user)
        {
            this.storageOption.PrintDataStoreValueOfUser(user);
        }
    
        public void storeEmailPassInCash(string Email,string Password)
        {
            storageOption.storecashEmail(Email, Password);
        }

        public bool EmailPassCheck(string Email,string Password)
        {
            return storageOption.isEmialMatchWithpass(Email, Password);
        }

        public User FindUser(string username) { 
            return storageOption.FindUser(username);
        }
    }
}
