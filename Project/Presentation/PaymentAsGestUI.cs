public class PaymentAsGestUI
{
    public static string FirstName = "";
    public static string LastName = "";
    public static string Email = "";
    public static string Phone = "";
    public static int Age = 0;
    public static void StartAsGest()
    {
        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine("Guest Checkout — Please fill in your details");
        Console.WriteLine("══════════════════════════════════════════");
        Console.WriteLine("First name:");
        string firstName = Console.ReadLine()!;
        FirstName = firstName;
        Console.WriteLine("Last name:");
        string lastName = Console.ReadLine()!;
        LastName = lastName;
        Console.WriteLine("Email:");
        string email = Console.ReadLine()!;
        Email = email;
        Console.WriteLine("Phone number:");
        string phone = Console.ReadLine()!;
        Phone = phone;
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