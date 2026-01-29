using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.PaymentProcessor
{
    internal class TestPaymentClass
    {
        static void Main()
        {

            // Observing Behaviour of Method overloading , function cheking taken place at CompileTime
            PaymentProcessorClass ParentPayment = new PaymentProcessorClass();

            ParentPayment.ProcessPayment(121212, 1111, 12000);
            ParentPayment.ProcessPayment("Union Cambay", "IFC0dnjnj" ,110000000011,12000);

            // Object Creation of Derived class and cheking behaviour of Method overriding , function cheking taken place at RunTime
            PaymentProcessorClass Obj = new UPIPaymentProcessorClass();
            PaymentProcessorClass Obj2 = new CreditCardPaymentProcessor();

            Obj.ProcessPayment(663377323, 1111234, 23000);
            Console.WriteLine("\n\n=================================\n\n");
            Obj2.ProcessPayment(123456789, 222456, 50000);
        }
    }
}
