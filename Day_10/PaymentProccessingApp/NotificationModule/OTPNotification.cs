using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.NotificationModule
{
    internal class OTPNotification
    {
        public int randomOTP;
        private string Email = string.Empty;
        private long Phone;
        public OTPNotification(string Email,long Phone,string Message )
        {
            this.Email = Email;
            this.Phone = Phone;
            randomOTP = (new Random()).Next(100000,500001);
        }

        public void Notify(string Message) 
        { 
           Console.WriteLine($"OTP is sent to both Email {this.Email} &  SMS on Phone{this.Phone} {Message}");
        }


    }
}
