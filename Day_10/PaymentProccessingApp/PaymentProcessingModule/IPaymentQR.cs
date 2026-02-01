using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.PaymentProcessingModule
{
    internal interface IPaymentQR
    {
        void PayWithQR(User user,double amount);
    }
}
