public class PaymentAsGestUI
{
    public static string FirstName = "";
    public static string LastName = "";
    public static string Email = "";
    public static string Phone = "";
    public static int Age = 0;

    public static void StartAsGest()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║       GUEST CHECKOUT - YOUR DETAILS      ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.WriteLine();

        FirstName = AskText("First name");
        LastName  = AskText("Last name");
        Email     = AskEmail();
        Phone     = AskPhone();
        Age       = AskAge();

        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║            DETAILS CONFIRMED             ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.WriteLine($"  Name  : {FirstName} {LastName}");
        Console.WriteLine($"  Email : {Email}");
        Console.WriteLine($"  Phone : {Phone}");
        Console.WriteLine($"  Age   : {Age}");
        Console.WriteLine();
    }

    private static string AskText(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (GuestValidationLogic.IsValidName(input)) return input;
            Console.WriteLine($"{label} cannot be empty.\n");
        }
    }

    private static string AskEmail()
    {
        while (true)
        {
            Console.Write("  Email: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (GuestValidationLogic.IsValidEmail(input)) return input;
            Console.WriteLine("Invalid email. Example: name@email.com\n");
        }
    }

    private static string AskPhone()
    {
        while (true)
        {
            Console.Write("  Phone number: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (GuestValidationLogic.IsValidPhone(input)) return input;
            Console.WriteLine("Invalid phone. Numbers only, at least 8 digits.\n");
        }
    }

    private static int AskAge()
    {
        while (true)
        {
            Console.Write("  Age: ");
            string input = Console.ReadLine()?.Trim() ?? "";
            if (GuestValidationLogic.IsValidAge(input)) return int.Parse(input);
            Console.WriteLine("Age must be a number between 5 and 120.\n");
        }
    }
}