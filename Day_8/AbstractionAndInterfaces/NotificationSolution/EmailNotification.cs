using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.NotificationSolution
{
    internal class EmailNotification : INotification
    {
        // Notify method of INotification interface (Note: Method must Public)
        public void Notify(string message)
        {
            Console.WriteLine("Email Notification sent to the User" + message);
        }
    }
}

