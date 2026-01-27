using System;
public class Account
{
    // Deaflut Accessibility of class field is private in c#. 
    static long AccNumSalt = 123456789;
    long _AccountNumber;
    string _AccountType;
    string _HolderName="Unknown";
    double _Balance=0;

    // Simple way to initialized values using contructor provided by OOP.
    public Account(string holderName, string? AccountType,double balance)
    {
        this._AccountNumber = AccNumSalt++;
        this._HolderName = holderName;
        this._AccountType = AccountType ?? "Saving";
        this._Balance = balance;
       
    }

    // Get & Set values using Concept of getter & setter Provided by OOP.
    public long AccountNumber
    {
        get { return _AccountNumber; }
    }
    public string AccountType
    {
        get { return _AccountType; }
    }
    public string HolderName
    {
        get { return _HolderName; }
        set { _HolderName = value; }
    }

    // getter setter provide encaptsulation to the actaul fields and also use for condition checks here it self.
    public double Balance
    {
        get { return _Balance; }
        set { if (_Balance-value > 0) _Balance = value;  }
    }
    
    // Define different methods at time of creating class blue-print rather then creating it the into main class 
    public void Deposit(double amount)
    {
        this.Balance += amount;
        Console.WriteLine($" Money is deposited successfully..");
        Console.WriteLine($" Balance is Updated successfully from account of {this.HolderName}, new balance is {this.Balance} ");
    }
    public void Withdrawal(double amount)
    {
        if (this.Balance - amount > 0) { this.Balance -= amount; }
        else { Console.WriteLine("Not Sufficient Balance..."); return; }
        Console.WriteLine($" Money is Withdraw successfully..");
        Console.WriteLine($" Balance is Updated successfully from account of {HolderName}, new balance is {Balance} ");

    }
    public void Display()
    {
        Console.WriteLine("============================================");
        Console.WriteLine(" Information of current Acount Holder is:");
        Console.WriteLine(" current Acount Holder Name is: " + this.HolderName);
        Console.WriteLine(" current Acount Number is: " + this.AccountNumber);
        Console.WriteLine(" current Acount Type is: " + this.AccountType);
        Console.WriteLine(" current Acount Balance is: " + this.Balance);
        Console.WriteLine("============================================");
    }

}

class AccountByOOPWays
{

   static void Main()
    {


        /// <summary>
        /// As we can see using OOP concept code is improved in belowe things:-
        /// 1) Accessiblity
        /// 2) Security
        /// 3) Prior Validation using getter & setter
        /// 4) Code readability
        /// 5) No manual-Repeatation
        /// 6) Code Reusability
        /// </summary>

        Console.WriteLine("You are in OOP oriented class");

        // Just create the object instance and use each feilds directly with the help of '.' operator 
        Account acc1 = new Account("Rana Raj H",null, 0);
        acc1.Display();
        acc1.Deposit(10000);
        acc1.Withdrawal(1000);
        acc1.Display();

        // no need to use manual variable names for individual properties like AccountNumber  and name use directly by creating an object  
        Account acc2 = new Account("Vadher Ravi R","Current", 0);
        acc2.Display();
        acc2.Deposit(10000);
        acc2.Withdrawal(1000);
        acc2.Display();

    }
}