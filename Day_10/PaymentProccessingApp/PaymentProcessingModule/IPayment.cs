using System;
using System.Collections.Generic;
using System.Text;
using PaymentProccessingApp.UserModule;
namespace PaymentProccessingApp.PaymentProcessingModule
{
    internal interface IPayment
    {
        void DoPayment(User user,int PIN, double amount);
    }
}
