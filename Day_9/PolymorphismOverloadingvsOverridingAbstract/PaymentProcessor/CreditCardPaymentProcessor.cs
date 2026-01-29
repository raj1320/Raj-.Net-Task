using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.PaymentProcessor
{
    internal class CreditCardPaymentProcessor : PaymentProcessorClass
    {
        // Overrided method
        public override void ProcessPayment(long CardNumber, int CardPIN, double Amount)
        {
            Console.WriteLine("Process Payment is Executed here");
            Console.WriteLine($"Payment for CardNumber {CardNumber} is initiated");
            Console.WriteLine($"CardPIN Matching.....");
            Thread.Sleep(2000);
            Console.WriteLine($"Amount {Amount} is Pay successfully");
        }
    }
}
