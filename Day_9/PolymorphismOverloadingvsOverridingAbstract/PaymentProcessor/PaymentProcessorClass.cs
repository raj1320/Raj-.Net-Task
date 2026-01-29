using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PolymorphismOverloadingvsOverridingAbstract.PaymentProcessor
{
    internal class PaymentProcessorClass
    {
        // overloaded Method
        public virtual void ProcessPayment(long ProcessID,int Password,double Amount)
        {
            Console.WriteLine("Process Payment is Executed here");
            Console.WriteLine($"Payment for ProcessID {ProcessID} is initiated");
            Console.WriteLine($"Password Matching.....");
            Thread.Sleep(2000);
            Console.WriteLine($"Amount {Amount} is Pay successfully");
        }
        // overloaded Method
        public void ProcessPayment(string BranchName ,string IFSCCODE ,long AccountNumber , double Amount)
        {
            Console.WriteLine("Payment is Executed here");
            Console.WriteLine($"BranchName {BranchName} And IFSCCODE {IFSCCODE} finiding process is taken Place");
            Thread.Sleep(2000);
            Console.WriteLine($"Match Found");
            Console.WriteLine($"Amount {Amount} is Pay successfully form Account Number {AccountNumber}");
        }
      
        public PaymentProcessorClass() { }

    }
}
