using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.NotificationSolution
{
    internal class ClientCodeASNotificationServicesAs
    {
        // In future if any other Notification added
        // At that time this notification referance of INotification call Notify method according to the passed Object of concreate notifiction class in argument
        public void NotificationSent(INotification notification,string Message)
        {
            // calling argument object Notify method...
            notification.Notify(Message);
        }

        static void Main()
        {
            // Creating Notification service Object..
            ClientCodeASNotificationServicesAs serviceObject = new ClientCodeASNotificationServicesAs();
            

            // Call NotificationSent Method
            // Here i passed Object of SMSNotification and message as an argument of NotificationSent function..
            serviceObject.NotificationSent(new SMSNotification(), " Hello From SMS Notification ");


            // Call NotificationSent Method
            // Here i passed Object of EmailNotification and message as an argument of NotificationSent function..
            serviceObject.NotificationSent(new EmailNotification(), " Hello From Email Notification ");

            // Object mapping with referance is done at run time via Dynamic Method Dispatch
        }

    }

}
