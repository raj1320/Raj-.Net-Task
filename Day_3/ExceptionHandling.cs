using System;

// custome Exception class..
public class UnsufficientBalanceException : Exception
{
    public UnsufficientBalanceException(string msg): base(msg){ }
}

// BankAccount class..
public class BankAccount 
{
    int Acc_Num;
    string Name;
    double Balance;

    public BankAccount(int accNum, string name, double balance)
    {
        this.Acc_Num = accNum;
        this.Name = name;
        this.Balance = balance;
    }

    public double getBalance()
    {
        return this.Balance;
    }
    public void withdorwMoney(double money)
    {

        if (this.Balance - money > 0)
        {
            this.Balance -= money;
            Console.WriteLine($"Your Current Balance is {this.Balance}");
        }
        else
        {
            // throw custome exception 
            throw new UnsufficientBalanceException("You have not appropreate Balance for withdrow...");
        }

    }

    public void Display()
    {
        Console.WriteLine($"Your Account Number is {this.Acc_Num}");
        Console.WriteLine($"Your Account Name is {this.Name}");
        Console.WriteLine($"Your Current Balance is {this.Balance}");
    }

}

// class where exception handle
public class ExceptionHandlingForBank 
{
	
	static void Main(string[] args)
	{
        BankAccount bcc = new BankAccount(1001, "raj", 2330030);
        try
        {
           bcc.withdorwMoney(400000000);
        }
        catch (UnsufficientBalanceException usb) // handle exception
        {
            Console.WriteLine(usb.Message);
        }
        finally
        {
            bcc.Display(); // logging data..
        }
	}
}
