using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.NotificationModule
{
    internal class EmailNotification : INotification
    {
        private string Email = string.Empty;
        public EmailNotification(string Email) 
        {
            this.Email = Email;
        }
        public void Notify(string message)
        {
            Console.WriteLine($"Message is Sent on this Email :- {this.Email}");
            Console.WriteLine($"Message is : "+message);
        }
    }
}
