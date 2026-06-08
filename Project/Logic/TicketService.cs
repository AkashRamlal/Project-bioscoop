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

    public void ShowTickets(string email)
    {
        TicketsAccess ticketsAccess = new TicketsAccess();
        List<Ticket> tickets = ticketsAccess.GetByAccount(email);

        Console.Clear();
        Console.WriteLine("\n========== YOUR TICKET(S) ==========");

        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets found for your account.");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < tickets.Count; i++)
        {
            Console.WriteLine($"[{i + 1}]");
            Console.WriteLine(tickets[i].PrintTicket());
            Console.WriteLine();
        }

        Console.Write("Do you want to cancel a ticket? (y/n): ");
        string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (answer != "y")
        {
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Select ticket number to cancel: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > tickets.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }

        Ticket selected = tickets[choice - 1];

        string timeOnly = selected.Time.Split('-')[1].Trim();

        if (!TimeSpan.TryParse(timeOnly, out TimeSpan filmTime))
        {
            Console.WriteLine("Could not parse film time.");
            Console.ReadKey();
            return;
        }

        TimeSpan now = DateTime.Now.TimeOfDay;
        if (filmTime <= now || (filmTime - now).TotalHours < 2)
        {
            Console.WriteLine("Cancellation not allowed. Film starts in less than 2 hours or has already passed.");
            Console.ReadKey();
            return;
        }

        ticketsAccess.Delete(selected.Id);
        Console.WriteLine("\nTicket cancelled successfully.");
        Console.ReadKey();
    }

    public void ShowAllTickets()
    {
        TicketsAccess ticketsAccess = new TicketsAccess();
        List<Ticket> tickets = ticketsAccess.GetAll();

        Console.Clear();
        Console.WriteLine("\n========== ALL TICKETS ==========");

        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets found.");
            Console.ReadKey();
            return;
        }

        for (int i = 0; i < tickets.Count; i++)
        {
            Console.WriteLine($"[{i + 1}]");
            Console.WriteLine(tickets[i].PrintTicket());
            Console.WriteLine();
        }

        Console.Write("Do you want to cancel a ticket? (y/n): ");
        string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (answer != "y")
        {
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Select ticket number to cancel: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > tickets.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }

        Ticket selected = tickets[choice - 1];

        string timeOnly = selected.Time.Split('-')[1].Trim();

        if (!TimeSpan.TryParse(timeOnly, out TimeSpan filmTime))
        {
            Console.WriteLine("Could not parse film time.");
            Console.ReadKey();
            return;
        }

        TimeSpan now = DateTime.Now.TimeOfDay;
        if (filmTime <= now || (filmTime - now).TotalHours < 2)
        {
            Console.WriteLine("Cancellation not allowed. Film starts in less than 2 hours or has already passed.");
            Console.ReadKey();
            return;
        }

        ticketsAccess.Delete(selected.Id);
        Console.WriteLine("\nTicket cancelled successfully.");
        Console.ReadKey();
    }
    public List<string> ReservedTickets(string showKey)
    {
        TicketsAccess acces = new TicketsAccess();
        List<Ticket> AllTickets = acces.GetTickets();

        List<string> reservedSeats = new();
        foreach(Ticket ticket in AllTickets)
        {
            if(ticket.Hall == showKey)
            {
                reservedSeats.AddRange(ticket.Seats.Split(", ").Select(seat => seat.Split(" ")[0]));

                // "A1 (€11,00), A2 (€11,00)"
                // pak alles behalve de laatste 9 tekens
            }
        }
        return reservedSeats;
    }
}
