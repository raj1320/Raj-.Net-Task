using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.PaymentProcessor
{
    internal class UPIPaymentProcessorClass : PaymentProcessorClass
    {

        // Overrided Method
        public override void ProcessPayment(long UPIID, int UPIPIN, double Amount)
        {
            Console.WriteLine("Process Payment is Executed here");
            Console.WriteLine($"Payment for UPIID {UPIID} is initiated");
            Console.WriteLine($"UPIPIN Matching.....");
            Thread.Sleep(2000);
            Console.WriteLine($"Amount {Amount} is Pay successfully");
        }
    }
}
