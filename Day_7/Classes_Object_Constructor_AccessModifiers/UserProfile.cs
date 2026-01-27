using System;
using System.Text.RegularExpressions;

public class EmailPatternDoesNotMatchExcception : Exception
{
    public EmailPatternDoesNotMatchExcception(string Message) : base(Message ?? "") { }
}
public class UserProfile
{
    private string UserName=string.Empty;
    private string Email=string.Empty;
    private string Password="Test123";

    public UserProfile(){ }

    public UserProfile(string UserName, string Email, string Password)
    {
        this.UserName = UserName;
        // Regex syntex used to validate a email format
        string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"; 

        // IsMatch method is use for compare emial with the pre-define pattern
        if (Regex.IsMatch(Email, pattern))
        {
            this.Email = Email.ToLower();
        }
        else
        {
            // Throw custom exception 
            throw new EmailPatternDoesNotMatchExcception("Enter valid Email formate");
        }
        this.Password = Password;
    }

    //getter & setter for Feilds...
    public string GetPassword()
    {
        return this.Password;
    }

    public void changePassword(string Password)
    {
        this.Password = Password;
    }

    public string getUserName()
    {
        return this.UserName;
    }

    public void setUserName(string UserName)
    {
        this.UserName = UserName;
    }

    public string getEmail()
    {
        return this.Email;
    }

    public void setEmail(string Email)
    {
        string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"; 

        if (Regex.IsMatch(Email, pattern))
        {
            this.Email = Email;
        }
        else
        {
            throw new EmailPatternDoesNotMatchExcception("Enter valid formate Email");
        }
    }

}

public class User
{
    static void Main()
    {
        // Receive User Input 
        Console.WriteLine("Enter User Name : ");
        string UserName = Console.ReadLine() ?? "User";

        Console.WriteLine("Enter Email : ");
        string Email = Console.ReadLine() ?? "test123@gmail.com";

        Console.WriteLine("Enter Password : ");
        string Password = Console.ReadLine() ?? "Password";

        // Handle Exception
        try
        {   // Try to create an object of User with validation checking 
            UserProfile user = new UserProfile(UserName, Email, Password);


            //manual user creation and feild assignment 
            //UserProfile newuser = new UserProfile();
            //newuser.setUserName("Raj");
            //newuser.setEmail("raj123@gmail.com");
            //newuser.changePassword("Abc123");


            // Display  the content...
            Console.WriteLine($"UserName is :{user.getUserName()}");
            Console.WriteLine($"Email is :{user.getEmail()}");
            Console.WriteLine($"Password is :{user.GetPassword()}");



        }
        catch (EmailPatternDoesNotMatchExcception e)
        {
            Console.WriteLine(e.Message);
        }

        // Here if we applied each field as a public it is accesible to anywhere,
        // And any one can change there value directly , which laid down the security issues.So we must not declare any important feild as a public 
        // Always try to wrap up properties by using getter and setter (Encapsulation).
    }
}