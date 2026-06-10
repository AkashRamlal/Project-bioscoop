// LAYER: Presentation
// Called after seat selection. Example:
//   var hallData = new Dictionary<string, Dictionary<string, decimal>> {
//       { "Hall 1", new Dictionary<string, decimal> { { "A3", 15.00m }, { "B5", 10.00m } } }
//   };
//   PaymentUI.Start(filmName, time, hallData);

public class PaymentUI
{
    private readonly bool _isMember;
    private readonly PaymentService _paymentService;
    private readonly TicketService _ticketService;

    public PaymentUI(bool isMember)
    {
        _isMember = isMember;
        _paymentService = new PaymentService();
        _ticketService = new TicketService();
    }

    public void Start(
        string filmName,
        DateTime time,
        Dictionary<string, Dictionary<string, decimal>> hallData,
        string? email)
    {
        hallData = SeatReviewUI.Show(hallData);

        if (hallData.Count == 0)
            return;

        ShowCheckoutSummary(filmName, time, hallData);

        if (!_isMember)
        {
            Console.Clear();
            PaymentAsGestUI.StartAsGest();
            email = PaymentAsGestUI.Email;
        }

        bool paid = AskPayment();

        if (!paid)
        {
            Console.WriteLine("\nBooking cancelled. No ticket issued.");
            Console.ReadKey();
            return;
        }

        List<Ticket> tickets = _ticketService.CreateTickets(
            filmName,
            time,
            hallData,
            email ?? ""
        );

        Console.Clear();
        Console.WriteLine("\n========== YOUR TICKET(S) ==========");

        foreach (Ticket ticket in tickets)
        {
            Console.WriteLine(ticket.PrintTicket());
            Console.WriteLine();
        }

        Console.WriteLine("Enjoy the movie!");
        Console.ReadKey();
    }

    private void ShowCheckoutSummary(
        string filmName,
        DateTime time,
        Dictionary<string, Dictionary<string, decimal>> hallData)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║         CINEMA BOOKING SYSTEM        ║");
        Console.WriteLine("║              CHECKOUT                ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine($"\nSummary:");
        Console.WriteLine($"  Film  : {filmName}");
        Console.WriteLine($"  Time  : {time.ToString("yyyy-MM-dd HH:mm")}");

        decimal grandTotal = 0;

        foreach (var hall in hallData)
        {
            Console.WriteLine($"  Hall  : {hall.Key}");

            foreach (var seat in hall.Value)
            {
                Console.WriteLine($"    Seat {seat.Key} — €{seat.Value:F2}");
                grandTotal += seat.Value;
            }
        }

        Console.WriteLine($"\n  Total to pay: €{grandTotal:F2}");
        Console.WriteLine("\nPress any key to proceed to payment...");
        Console.ReadKey();
    }

    private bool AskPayment()
    {
        Console.Clear();
        Console.WriteLine("\n========== PAYMENT ==========");
        Console.WriteLine("Choose a payment method:");
        Console.WriteLine("  1. iDEAL");
        Console.WriteLine("  2. PayPal");
        Console.Write("Your choice: ");

        string choice = Console.ReadLine()?.Trim() ?? "";

        if (choice == "1")
        {
            string bank = AskBank();

            bool success = _paymentService.ProcessIDeal(bank);

            if (success)
            {
                Console.WriteLine($"\nRedirecting to {bank}...");
                Console.WriteLine("Simulating payment approval...");
                Console.WriteLine("Payment successful via iDEAL!");
            }
            else
            {
                Console.WriteLine("Invalid bank selection. Payment cancelled.");
            }

            return success;
        }

        if (choice == "2")
        {
            Console.Clear();
            Console.WriteLine("\n-- PayPal Payment --");
            Console.Write("Enter your PayPal email: ");

            string paypalEmail = Console.ReadLine()?.Trim() ?? "";

            bool success = _paymentService.ProcessPayPal(paypalEmail);

            if (success)
            {
                Console.WriteLine($"\nLogging in as {paypalEmail}...");
                Console.WriteLine("Simulating payment approval...");
                Console.WriteLine("Payment successful via PayPal!");
            }
            else
            {
                Console.WriteLine("Invalid email. Payment cancelled.");
            }

            return success;
        }

        Console.WriteLine("Invalid choice. Payment cancelled.");
        return false;
    }

    private string AskBank()
    {
        Console.Clear();
        Console.WriteLine("\n-- iDEAL Payment --");
        Console.WriteLine("Select your bank:");
        Console.WriteLine("  1. ABN AMRO");
        Console.WriteLine("  2. ING");
        Console.WriteLine("  3. Rabobank");
        Console.WriteLine("  4. SNS Bank");
        Console.Write("Your bank: ");

        string bank = Console.ReadLine()?.Trim() ?? "";

        return bank switch
        {
            "1" => "ABN AMRO",
            "2" => "ING",
            "3" => "Rabobank",
            "4" => "SNS Bank",
            _ => ""
        };
    }
}