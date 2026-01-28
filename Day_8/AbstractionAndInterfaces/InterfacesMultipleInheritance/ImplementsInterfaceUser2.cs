using AbstractionAndInterfaces.NotificationSolution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace AbstractionAndInterfaces.InterfacesMultipleInheritance
{
    internal class ImplementsInterfaceUser2 : IAdminUser
    {
        // For Generating Random Session Time for Maintain user login until it compeletes Session timing
        private Random random = new Random();

        // For Maintain Data of Registered Admin User
        private Dictionary<string, string> RegisterUser = new Dictionary<string, string>() { { "raj", "Raj1320nsn" }, { "ravi", "Ravi1320nsn" }, { "het", "Het1320nsn" } };
       
        // For Maintain Data of Feature along with their Status
        private Dictionary<string,string> UpCommingFeatutreList = new Dictionary<string, string>() { {"CreatePost","Completed" }, { "CreateBlog", "In Testing"}, { "Reviews","In Deployment"} };
       
        // For logout request check
        private int SessionTime = 0;

        // For counting total logged in time of Admin user
        private Stopwatch Stopwatch= new Stopwatch();

        // Login with username & password check functionality, also start stopwatch to messure logged in time
        public int Login(string username, string password)
        {

            var isAuthenticate = () =>
            {
                return RegisterUser.ContainsKey(username) && RegisterUser[username] == password;
            };


            if (isAuthenticate()) Console.WriteLine("Login Successfully....");
            else Console.WriteLine("User Not Authenticate...");
            SessionTime = random.Next(1000,2000);
            Stopwatch.Start();
            return SessionTime;
        }
        
        // Logout with SessionTime , if admin has a time to expire session it remain looged in
        public void Logout(int SessionTime)
        {
            Stopwatch.Stop();
            if(Stopwatch.ElapsedMilliseconds >= SessionTime)
            {
                Console.WriteLine("Your session is expire your logout successfully");
                SessionTime = 0;
            }
            else
            {
                Console.WriteLine("Your session is not expire you are still login..");
                Console.WriteLine($"Your session expires in {Math.Abs(SessionTime - Stopwatch.ElapsedMilliseconds)} Miliseconds");
            }
        }
      
        // Email notification sent
        public void SentNotification(INotification notification, string message)
        {
            notification.Notify(message);
        }
      
        // New Feature added to the Dictionary
        public void AddNewFeature(string featureName)
        {
            UpCommingFeatutreList.Add(featureName,"Panding");

            Console.WriteLine("Your Upcomming Feature List");
            foreach (KeyValuePair<string,string> keyValuePair in UpCommingFeatutreList) { Console.WriteLine(keyValuePair.Key+ " is " + keyValuePair.Value); }


        }
       
        // Return total registered user count
        public int CalculateUserCount()
        {
            return RegisterUser.Count;
        }


        // Testing Main Method...
        static void Main()
        {
            // creating object of second class which implements IAdmin interface
            ImplementsInterfaceUser2 obj = new ImplementsInterfaceUser2();
            int LoginSessionTimer = 0;


            // Manual Method calling & cheking...

            LoginSessionTimer = obj.Login("raj", "Raj1320nsn");
            Console.WriteLine();

            obj.SentNotification(new EmailNotification(), " Notification Testing...");
            Console.WriteLine();

            obj.AddNewFeature("Ai base Post Editing");
            Console.WriteLine();

            Console.WriteLine("Total Admin Count:" + obj.CalculateUserCount());
            Console.WriteLine();

            // To show logout feature , it change their output with every differnt execution
            Thread.Sleep(1500);
            obj.Logout(LoginSessionTimer);

        }
    }
}
