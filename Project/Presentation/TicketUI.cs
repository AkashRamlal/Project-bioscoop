public class TicketUI
{
    private readonly TicketService _ticketService;

    public TicketUI()
    {
        _ticketService = new TicketService();
    }

    public void ShowTickets(AccountModel acc)
    {
        List<Ticket> tickets = _ticketService.GetTicketsByEmail(acc.Email);

        ShowTicketList(tickets, "YOUR TICKET(S)", acc);
    }

    public void ShowAllTickets()
    {
        List<Ticket> tickets = _ticketService.GetAllTickets();

        ShowTicketList(tickets, "ALL TICKETS");
    }

    private void ShowTicketList(List<Ticket> tickets, string title, AccountModel? acc = null)
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

        Console.Write("Enter 1 to cancel a ticket or 2 to change ticket date: ");
        string answer = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (answer != "1" && answer != "2")
        {
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }
        Console.Write("Select ticket number to " + (answer == "1" ? "cancel" : "change") + ": ");

        if (!int.TryParse(Console.ReadLine(), out int choice) ||
            choice < 1 ||
            choice > tickets.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            return;
        }

        Ticket selected = tickets[choice - 1];

        if (answer == "1")
        {
            bool cancelled = _ticketService.CancelTicket(selected);
            if (!cancelled)
            {
                Console.WriteLine("Cancellation not allowed. Film starts in less than 2 hours or has already passed.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Ticket cancelled successfully.");
        }
        else if (answer == "2")
        {
            bool changed = _ticketService.ChangeTicket(selected, acc);
            if (changed)
            {
                Console.WriteLine("Ticket changed successfully.");
            }
            else
            {
                Console.WriteLine("Change not allowed. Film starts in less than 2 hours or has already passed.");
            }
        }
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }
}