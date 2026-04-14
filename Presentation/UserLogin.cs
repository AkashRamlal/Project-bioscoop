static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the login page\n");
        Console.WriteLine("Please enter your email address");
        string email = Console.ReadLine()!;
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine()!;
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc != null)
        {
            //Write some code to go back to the menu
            Menu.Start(acc.FullName);
        }
        else
        {
            Console.WriteLine("No account found with that email and password");
        }
    }
}