// LAYER: Logic
public class TicketService
{

    public void HandleCheckout(string filmName, string time, Dictionary<string, Dictionary<string, decimal>> hallData, string email)
    {
        TicketsAccess ticketsAccess = new TicketsAccess();
        var paymentService = new PaymentService();
        bool paid = paymentService.ProcessPayment();

        if (!paid)
        {
            Console.WriteLine("\nBooking cancelled. No ticket issued.");
            return;
        }
        Console.Clear();
        Console.WriteLine("\n========== YOUR TICKET(S) ==========");

        // One ticket per hall
        foreach (var hall in hallData)
        {
            string hallName = hall.Key;

            // Format seats: "A3 (€15.00), B5 (€10.00)"
            string seats = string.Join(", ", hall.Value.Select(s => $"{s.Key} (€{s.Value:F2})"));

            // Total = sum of all seat prices in this hall
            decimal total = hall.Value.Values.Sum();

            var ticket = new Ticket(filmName, hallName, time, seats, total, email);
            ticketsAccess.Write(ticket);
            Console.WriteLine(ticket.PrintTicket());
            Console.WriteLine();
        }

        Console.WriteLine("Enjoy the movie!");
    }

    public List<string> ReservedTickets(string hall, string time)
    {
        TicketsAccess acces = new TicketsAccess();
        List<Ticket> AllTickets = acces.GetTickets();

        List<string> reservedSeats = new();
        foreach(Ticket ticket in AllTickets)
        {
            if(ticket.Hall == hall && ticket.Time == time)
            {
                reservedSeats.AddRange(ticket.Seats.Split(", ").Select(seat=>seat[..^9]));

                // "A1 (€11,00), A2 (€11,00)"
                // pak alles behalve de laatste 9 tekens
            }
        }
        return reservedSeats;
    }
}
