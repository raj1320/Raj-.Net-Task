using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PaymentProccessingApp.UserModule
{
    internal class UPIDetails
    {
        string _UPIId = string.Empty;
        int _UPIPIN;
        double _Balance;

        public string UPIId
        {
            get { return _UPIId; } 
            set { _UPIId = value; } 
        }

        public int UPIPIN
        {
            get { return _UPIPIN; }
            set { _UPIPIN = value; }
        }

        public double Balance
        {
            get { return _Balance; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Not Suffficent Balance");
                }
                else _Balance = value;
            }
        }
    }
}
