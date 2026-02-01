using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.UserModule
{
    internal class BankDetails
    {
        string _BankName = string.Empty;
        string _BanchName = string.Empty;
        string _IFSCCODE = string.Empty;
        long _AccNum ;
        int _PIN;
        double _Balance;

        public string BankName
        {
            get { return _BankName; }
            set { _BankName = value; }
        }

        public string BanchName
        {
            get { return _BanchName; }
            set { _BanchName = value; }
        }
        public string IFSCCODE
        {
            get { return _IFSCCODE; }
            set { _IFSCCODE = value; }
        }
        public long AccNum
        {
            get { return _AccNum; }
            set { _AccNum = value; }
        }

        public int PIN
        {
            get { return _PIN; }
            set { _PIN = value; }
        }
        public double Balance
        {
            get { return  _Balance; }
            set {
                 _Balance = value;
            }
        }
    }
}
