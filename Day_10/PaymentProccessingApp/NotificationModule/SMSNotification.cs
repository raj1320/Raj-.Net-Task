using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.NotificationModule
{
    internal class SMSNotification : INotification
    {

        private long Phone;
        public SMSNotification(long Phone) 
        {
            this.Phone = Phone;
        }
        public void Notify(string message)
        {
            Console.WriteLine($"Message is Sent on this Phone Number :- {this.Phone}");
            Console.WriteLine($"Message is : " + message);
        }
    }
}

