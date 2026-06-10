public class TicketService
{
    private readonly TicketsAccess _ticketsAccess;

    public TicketService()
    {
        _ticketsAccess = new TicketsAccess();
    }

    public List<Ticket> CreateTickets(
        string filmName,
        DateTime time,
        Dictionary<string, Dictionary<string, decimal>> hallData,
        string email)
    {
        List<Ticket> createdTickets = new();

        foreach (var hall in hallData)
        {
            string hallName = hall.Key;
            string seats = string.Join(", ", hall.Value.Select(s => $"{s.Key} (€{s.Value:F2})"));
            decimal total = hall.Value.Values.Sum();

            Ticket ticket = new Ticket(filmName, hallName, time, seats, total, email);

            _ticketsAccess.Write(ticket);
            createdTickets.Add(ticket);
        }

        return createdTickets;
    }

    public List<Ticket> GetTicketsByEmail(string email)
    {
        return _ticketsAccess.GetByAccount(email);
    }

    public List<Ticket> GetAllTickets()
    {
        return _ticketsAccess.GetAll();
    }

    public bool CancelTicket(Ticket ticket)
    {
        if (!CanCancelTicket(ticket))
            return false;

        _ticketsAccess.Delete(ticket.Id);
        return true;
    }

    public bool CanCancelTicket(Ticket ticket)
    {
        DateTime filmDateTime = ticket.Date;
        DateTime now = DateTime.Now;

        return filmDateTime > now && (filmDateTime - now).TotalHours >= 2;
    }

    public List<string> ReservedTickets(string filmName, DateTime date, string hall)
    {
        List<Ticket> allTickets = _ticketsAccess.GetTickets();
        List<string> reservedSeats = new();

        foreach (Ticket ticket in allTickets)
        {
            if (ticket.FilmName == filmName && ticket.Hall == hall && ticket.Date == date)
            {
                reservedSeats.AddRange(ticket.Seats.Split(", ").Select(seat => seat.Split(" ")[0]));
            }
        }

        return reservedSeats;
    }
}