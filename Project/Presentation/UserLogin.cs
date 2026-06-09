static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    static int attempts = 0;


    public static AccountModel? Start()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the login page\n");

        while (attempts < 3)
        {
            Console.WriteLine("Please enter your email address");
            string email = Console.ReadLine()!;

            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine()!;

            AccountModel acc = accountsLogic.CheckLogin(email, password);

            if (acc != null)
            {
                attempts = 0;
                return acc;
            }

            attempts++;
            Console.WriteLine($"No account found. Attempts left: {3 - attempts}");
        }

        Console.WriteLine("Forgot your password? y/n");
        string answer = Console.ReadLine()!.ToLower();

        if (answer == "y")
        {
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine()!;

            EditAccountLogic.ForgotPassword(email);
        }

        attempts = 0;
        return null;
    }
}