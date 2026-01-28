using AbstractionAndInterfaces.NotificationSolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractionAndInterfaces.InterfacesMultipleInheritance
{
    internal class ImplementsInterfaceUser1 : IAdminUser
    {
        // For Generating Random Token Time for cheking when user requested for logout 
        private Random random = new Random();

        // For Maintain Data of Logged in Admin User
        private Dictionary<string, string> Loggeduser = new Dictionary<string, string>() { { "raj", "Raj1320nsn" },{ "ravi", "Ravi1320nsn" },{"het", "Het1320nsn" } };

        // For Maintain Data of Feature
        private List<string> UpCommingFeatutreList = new List<string>() { "CreatePost","CreateBlog","Reviews"};

        // For logout request check
        private int token = 0;


        // Login with username & password check functionality, return token.
        public int Login(string username, string password){
            
            var isAuthenticate = () =>
            {
                return Loggeduser.ContainsKey(username) && Loggeduser[username] == password;
            };


            if (isAuthenticate()) Console.WriteLine("Login Successfully....");
            else Console.WriteLine("User Not Authenticate...");
            token = random.Next(100000, 200000);
            return token;
        }

        // Logout if admin pass valid token
        public void Logout(int token)
        {
            if (this.token == token)
            {
                Console.WriteLine("Logout successfully....");
                token = 0;
            }
            else
            {
                Console.WriteLine("Envalid Token...");
            }
        }

        // SMS notification sent
        public void SentNotification(INotification notification,string message)
        {
            notification.Notify(message);
        }

        // New Feature added to the List
        public void AddNewFeature(string featureName) {
            UpCommingFeatutreList.Add(featureName);

            Console.WriteLine("Your Upcomming Feature List");
            foreach(string  feature in UpCommingFeatutreList) { Console.WriteLine(feature); }
            

        }

        // Return total Loggen in user count
        public int CalculateUserCount() {
            return Loggeduser.Count;
        }


        // Testing Main Method...
        static void Main()
        {
            // creating object of first class which implements IAdmin interface
            ImplementsInterfaceUser1 obj = new ImplementsInterfaceUser1();
            int LoginToken = 0;

            // Manual Method calling & cheking...
            LoginToken = obj.Login("raj", "Raj1320nsn");
            Console.WriteLine();
          
            obj.SentNotification(new SMSNotification(), " Notification Testing...");
            Console.WriteLine();
            
            obj.AddNewFeature("Ai base Post Editing");
            Console.WriteLine();
            
            Console.WriteLine("Total Admin Count:" + obj.CalculateUserCount());
            Console.WriteLine();
            
            obj.Logout(LoginToken);
        }
    }
}
