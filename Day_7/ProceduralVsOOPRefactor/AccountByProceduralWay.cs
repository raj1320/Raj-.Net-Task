using Microsoft.VisualBasic;
using System;
class AccountByProceduralWay
{
    // As we can see in procedural languages functions are more important then data we can simply pass the data inside of any funtion ,
    // which reduce the security of the data.
    static void Deposit(string HolderName, ref double Balance,double amount)
    {
        Balance += amount;
        Console.WriteLine($" Money is deposited successfully..");
        Console.WriteLine($" Balance is Updated successfully from account of {HolderName}, new balance is {Balance} ");
    }
    static void Withdrawal(string HolderName, ref double Balance, double amount)
    {   if (Balance - amount > 0) { Balance -= amount; }
        else { Console.WriteLine("Not Sufficient Balance..."); return; }
        Console.WriteLine($" Money is Withdraw successfully..");
        Console.WriteLine($" Balance is Updated successfully from account of {HolderName}, new balance is {Balance} ");

    }
    static void Display(int AccountNumber,string HolderName,double Balance)
    {
        Console.WriteLine("============================================");
        Console.WriteLine(" Information of current Acount Holder is:");
        Console.WriteLine(" current Acount Holder Name is: "+HolderName);
        Console.WriteLine(" current Acount Number is: "+ AccountNumber);
        Console.WriteLine(" current Acount Balance is: "+ Balance);
        Console.WriteLine("============================================");
    }
    static void Main()
    {
        // We have to set manual variable values for each account holder ....
        int AccountNumber;
        string HolderName;
        double Balance;

        AccountNumber = 1234567890;
        HolderName = "Rana Raj H.";
        Balance = 10000;

        int AccountNumber2;
        string HolderName2;
        double Balance2;

        AccountNumber2 = 2134567890;
        HolderName2 = "Vadher Ravi R.";
        Balance2 = 20000;

        // Manual call for individual Account holder
        Display(AccountNumber, HolderName, Balance);
        
        Deposit(HolderName,ref Balance,1500);
        Withdrawal(HolderName,ref Balance,500);

        Display(AccountNumber,HolderName,Balance);

        // Manual call for individual Account holder
        Display(AccountNumber2, HolderName2, Balance2);

        Deposit(HolderName2, ref Balance2, 1500);
        Withdrawal(HolderName2, ref Balance2, 500);

        Display(AccountNumber2, HolderName2, Balance2);

    }
}