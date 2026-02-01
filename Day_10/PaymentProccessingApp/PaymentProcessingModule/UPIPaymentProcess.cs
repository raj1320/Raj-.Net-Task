/// <summary>
///  Here this Module is follow ISP (Interfae Segrigation Principle) beacuse UPIPaymentProcess Follow both IPayment,IPaymentQR interfaces
///  And The NetBankingPaymentProcess follow Only one interface called  IPayment so that's how both interface works differently and follow ISP
///  Classes have implements it according to their needs..
/// </summary>

using PaymentProccessingApp.UserModule;
using System;
using System.Collections.Generic;
using System.Text;
using PaymentProccessingApp.DataBaseServices;
namespace PaymentProccessingApp.PaymentProcessingModule
{
    internal class UPIPaymentProcess : IPayment,IPaymentQR
    {
         DataBaseConnectionAndServices DBservice = new DataBaseConnectionAndServices(new StoreAtLocalStore());

        public void DoPayment(User user,int PIN,double amount)
        {
            try 
            { 
                  if (user.ListOfUPIDetails[0].UPIPIN != PIN)
                  {

                    throw new Exception("\nUPIID or PIN is incorrect\n");

                   }

                   user.ListOfUPIDetails[0].Balance -= amount;
                   Thread.Sleep(100);
                   Console.WriteLine("\n\nPayment Successfull...");
                   Console.WriteLine("Your cuurent State is : \n\n");
                   DBservice.PrintCurrentUser(user);
                   Console.WriteLine("\n\n");

            }catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                Console.WriteLine("Transection Failed..");
            }
        }
      
        public void PayWithQR(User user,double amount)
        {
            int Num=0;
            Random random = new Random();
            int num = random.Next(5, 8);
            for (int i = 0; i < num; i++)
            {
                Console.Write("| ||");
            }

           ProgramService.ForINtMemoryAllocation_Validation(ref Num," ");
            if (Num == num*3) 
            {
                try
                {
                    user.ListOfUPIDetails[0].Balance -= amount;
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
            else
            {
                Console.WriteLine("Incorrect gauess..");
            }

    }
}
}
