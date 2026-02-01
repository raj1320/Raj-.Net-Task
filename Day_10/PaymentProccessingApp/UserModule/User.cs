using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PaymentProccessingApp.UserModule
{
    internal class User
    {
        List<BankDetails> _ListOfBankDetails = new List<BankDetails>();
        List<UPIDetails> _ListOfUPIDetails = new List<UPIDetails>();
        string _Name = string.Empty;
        string _Email = string.Empty;
        long _Phone;
        string _Password = string.Empty;

        

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Email
        {
            get { return _Email; }
            set {

                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if(Regex.IsMatch(value,pattern)) _Email = value;
                else { throw new Exception("Enter valid fromate of Email....\n Registration is failed"); }
            }
        }
        public long Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public List<BankDetails> ListOfBankDetails
        {
            get { return _ListOfBankDetails; }
            set
            {
                _ListOfBankDetails = value; 
            }
        }

        public List<UPIDetails> ListOfUPIDetails
        {
            get { return _ListOfUPIDetails; }
            set
            {
                _ListOfUPIDetails = value;
            }
        }
    }
}




