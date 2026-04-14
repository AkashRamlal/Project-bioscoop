// LAYER: Logic
public class PaymentService
{
    // Returns true if payment was successful
    public bool ProcessPayment()
    {
        Console.WriteLine("\n========== PAYMENT ==========");
        Console.WriteLine("Choose a payment method:");
        Console.WriteLine("  1. iDEAL");
        Console.WriteLine("  2. PayPal");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine()?.Trim() ?? "";

        switch (choice)
        {
            case "1":
                return ProcessIDeal();
            case "2":
                return ProcessPayPal();
            default:
                Console.WriteLine("Invalid choice. Payment cancelled.");
                return false;
        }
    }

    private bool ProcessIDeal()
    {
        Console.WriteLine("\n-- iDEAL Payment --");
        Console.WriteLine("Select your bank:");
        Console.WriteLine("  1. ABN AMRO");
        Console.WriteLine("  2. ING");
        Console.WriteLine("  3. Rabobank");
        Console.WriteLine("  4. SNS Bank");
        Console.Write("Your bank: ");

        string bank = Console.ReadLine()?.Trim() ?? "";
        string[] banks = { "ABN AMRO", "ING", "Rabobank", "SNS Bank" };

        if (int.TryParse(bank, out int idx) && idx >= 1 && idx <= 4)
        {
            Console.WriteLine($"\nRedirecting to {banks[idx - 1]}...");
            Console.WriteLine("Simulating payment approval...");
            Console.WriteLine("Payment successful via iDEAL!");
            return true;
        }

        Console.WriteLine("Invalid bank selection. Payment cancelled.");
        return false;
    }

    private bool ProcessPayPal()
    {
        Console.WriteLine("\n-- PayPal Payment --");
        Console.Write("Enter your PayPal email: ");
        string email = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            Console.WriteLine("Invalid email. Payment cancelled.");
            return false;
        }

        Console.WriteLine($"\nLogging in as {email}...");
        Console.WriteLine("Simulating payment approval...");
        Console.WriteLine("Payment successful via PayPal!");
        return true;
    }
}
