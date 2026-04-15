// LAYER: Presentation
// Called after seat selection. Example:
//   var hallData = new Dictionary<string, Dictionary<string, decimal>> {
//       { "Hall 1", new Dictionary<string, decimal> { { "A3", 15.00m }, { "B5", 10.00m } } }
//   };
//   PaymentUI.Start(filmName, time, hallData);

public class PaymentUI
{
    public static void Start(string filmName, string time, Dictionary<string, Dictionary<string, decimal>> hallData)
    {
        // Step 1: Let user review seats, apply discounts or cancel seats
        hallData = SeatReviewUI.Show(hallData);

        if (hallData.Count == 0)
            return; // All seats cancelled, nothing to pay

        // Step 2: Show checkout summary
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║         CINEMA BOOKING SYSTEM        ║");
        Console.WriteLine("║              CHECKOUT                ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine($"\nSummary:");
        Console.WriteLine($"  Film  : {filmName}");
        Console.WriteLine($"  Time  : {time}");

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

        // Step 3: Payment + ticket
        var ticketService = new TicketService();
        ticketService.HandleCheckout(filmName, time, hallData);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

