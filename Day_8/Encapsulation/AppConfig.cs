using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    public class AppConfig
    {   
        // Define each field as a private and readonly to be immutable after one assignment
        readonly string _AppName = string.Empty;
        readonly float _Version = 0;
        readonly string _CreatedDate = DateTime.Today.Date.ToShortDateString();

        // Set value of each fields with the help of constructor
        public AppConfig(string appname,float version,DateTime date) {
            this._AppName = appname;
            this._Version = version;
            this._CreatedDate = date.Date.ToShortDateString();
        }
        
        // Getter Only , for get the values.. 
        public string AppName
        {
            get { return _AppName; } 
        }
        public float Version
        {
            get { return _Version; }
        }
        public string CreatedDate
        {
            get { return _CreatedDate; }
        }

    }

    internal class AppConfigUser
    {
       static void Main()
        {
            // Define Object of AppConfig and Assign values via constructor.
            AppConfig user = new AppConfig("Zometo",0.1f,DateTime.Now);

            // Display the content
            Console.WriteLine(user.AppName);
            Console.WriteLine(user.Version);
            Console.WriteLine(user.CreatedDate);

            // throw compile time exception due to try to access private field of another class
            // if you make a field public then also not possible, due to first assignment ( readOnly property don't allow to chnage the value after the first assignment).
            //user._AppName="Zepto";
        }
    }
}
