using System.Runtime.ConstrainedExecution;

/// <summary>
/// It Follows LSP clearly :- subtypes must be substitutable for their base types without altering the correctness of the program.
/// Any class EmailNotification, OTPNotification, SMSNotification should be usable wherever INotification is expected.
/// None of these classes should throw unexpected exceptions or ignore the contract defined by INotification.
/// The Send method must always deliver the message in its respective medium. If one implementation fails or changes semantics, it breaks LSP.
/// </summary>



using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProccessingApp.NotificationModule
{
    internal interface INotification
    {
        void Notify(string Message);
    }
}
