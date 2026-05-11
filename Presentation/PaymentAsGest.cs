public class PaymentAsGestUI
{
    public static void StartAsGest()
    {
        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine("Guest Checkout — Please fill in your details");
        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine("First name:");
        string FirstName = Console.ReadLine()!;
        Console.WriteLine("Last name:");
        string LastName = Console.ReadLine()!;
        Console.WriteLine("Email:");
        string Email = Console.ReadLine()!;
        Console.WriteLine("Phone number:");
        string Phone = Console.ReadLine()!;
        int age;
        while (true)
        {
            Console.Write("Enter your Age: ");
            try
            {
                age = int.Parse(Console.ReadLine()!);
                break;
            }
            catch
            {
                Console.WriteLine("Invalid age input. Please enter a valid number.");
            }
        }
    }
}