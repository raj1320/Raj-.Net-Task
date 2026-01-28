using AbstractionAndInterfaces.NotificationSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.InterfacesMultipleInheritance
{
    // Interface
    internal interface IAdminUser : IUser
    {
        // Some List of Activities Done By Admin User
        
        // Admin User can broadcast or Unicast notification 
        void SentNotification(INotification notification,string message);
        
        // Admin User can review the feature and add it accordingly
        void AddNewFeature(string featureName);

        // Admin User can Watch the count of Registered or loggedin User...
        int CalculateUserCount();
        

    }
}
