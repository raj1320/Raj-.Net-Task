using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.InterfacesMultipleInheritance
{
    // Interface
    internal interface IUser
    {
        // Some List of Activities Done By Every User

        // User can Login 
        int Login(string username, string password);
        
        // User can Logout
        void Logout(int token);
    }
}
