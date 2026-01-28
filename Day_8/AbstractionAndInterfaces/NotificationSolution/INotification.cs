using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.NotificationSolution
{
    // Interface
    internal interface INotification
    {
        // Every child method have to define their own logic for Notify method 
        void Notify(string message);
    }
}
