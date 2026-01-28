using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.NotificationSolution
{
    internal class SMSNotification : INotification
    {
        // Notify method of INotification interface (Note: Method must Public)
        public void Notify(string message)
        {
            Console.WriteLine("SMS Notification sent to the User" +message );
        }
    }
}

