


using PaymentProccessingApp.DataBaseServices;
using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.PaymentProcessingModule
{
    internal class NetBankingPaymentProcess : IPayment
    {
        DataBaseConnectionAndServices DBservice = new DataBaseConnectionAndServices(new StoreAtLocalStore());

        public void DoPayment(User user, int PIN, double amount)
        {
            try
            {

                
                if (user.ListOfBankDetails[0].PIN != PIN)
                {

                    throw new Exception("\nBankName or PIN is incorrect\n");

                }

                user.ListOfBankDetails[0].Balance -= amount;
                Thread.Sleep(100);
                Console.WriteLine("\n\nPayment Successfull...");
                Console.WriteLine("Your cuurent State is : \n\n");
                DBservice.PrintCurrentUser(user);
                Console.WriteLine("\n\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Transection Failed..");
            }
        }
    }
}



