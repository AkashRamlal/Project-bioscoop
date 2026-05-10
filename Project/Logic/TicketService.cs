// LAYER: Logic
public class TicketService
{
    public void HandleCheckout(string filmName, string time, Dictionary<string, Dictionary<string, decimal>> hallData)
    {
        var paymentService = new PaymentService();
        bool paid = paymentService.ProcessPayment();

        if (!paid)
        {
            Console.WriteLine("\nBooking cancelled. No ticket issued.");
            return;
        }

        Console.WriteLine("\n========== YOUR TICKET(S) ==========");

        // One ticket per hall
        foreach (var hall in hallData)
        {
            string hallName = hall.Key;

            // Format seats: "A3 (€15.00), B5 (€10.00)"
            string seats = string.Join(", ", hall.Value.Select(s => $"{s.Key} (€{s.Value:F2})"));

            // Total = sum of all seat prices in this hall
            decimal total = hall.Value.Values.Sum();

            var ticket = new Ticket(filmName, hallName, time, seats, total);

            Console.WriteLine(ticket.PrintTicket());
            Console.WriteLine();
        }

        Console.WriteLine("Enjoy the movie!");
    }
}
