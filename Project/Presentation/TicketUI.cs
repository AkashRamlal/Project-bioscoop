public class TicketUI
{
    private readonly TicketService _ticketService;

    public TicketUI()
    {
        _ticketService = new TicketService();
    }

    public void ShowTickets(string email)
    {
        List<Ticket> tickets = _ticketService.GetTicketsByEmail(email);

        ShowTicketList(tickets, "YOUR TICKET(S)");
    }

    public void ShowAllTickets()
    {
        List<Ticket> tickets = _ticketService.GetAllTickets();

        ShowTicketList(tickets, "ALL TICKETS");
    }

    private void ShowTicketList(List<Ticket> tickets, string title)
    {
        Console.Clear();
        Console.WriteLine($"\n========== {title} ==========");

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

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 ||
            choice > tickets.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }

        Ticket selected = tickets[choice - 1];

        bool cancelled = _ticketService.CancelTicket(selected);

        if (!cancelled)
        {
            Console.WriteLine("Cancellation not allowed. Film starts in less than 2 hours or has already passed.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nTicket cancelled successfully.");
        Console.ReadKey();
    }
}