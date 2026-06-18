public class Ticket
{
    public int Id { get; set; } = 0;
    public string FilmName { get; set; } = "";
    public string Hall { get; set; } = "";
    public DateTime Date { get; set; }
    public string Seats { get; set; } = "";
    public decimal TotalPrice { get; set; }
    public string Email { get; set; } = "";
    public Dictionary<string, decimal> HallData { get; set; } = new Dictionary<string, decimal>();

    public Ticket() { }

    public Ticket(string filmName, string hall, DateTime date, string seats, decimal totalPrice, string email, Dictionary<string, decimal> hallData)
    {
        HallData = hallData;
        FilmName = filmName;
        Hall = hall;
        Date = date;
        Seats = seats;
        TotalPrice = totalPrice;
        Email = email;
    }
    
    public string PrintTicket()
    {
        int width = 60;
        int innerWidth = width - 4;
        string border = new string('*', width);

        string seatsStr = $"Seats: {Seats}";
        var seatLines = new List<string>();
        int seatPrefix = "Seats: ".Length;

        while (seatsStr.Length > innerWidth)
        {
            int cut = seatsStr.LastIndexOf(',', innerWidth);
            if (cut == -1) cut = innerWidth;
            seatLines.Add(seatsStr[..cut].Trim());
            seatsStr = new string(' ', seatPrefix) + seatsStr[(cut + 1)..].Trim();
        }
        seatLines.Add(seatsStr);

        string ticket = border + "\n";
        ticket += "* " + $"Reservation #: {Id}".PadRight(innerWidth)        + " *\n";
        ticket += "* " + $"Film: {FilmName}".PadRight(innerWidth)            + " *\n";
        ticket += "* " + $"Hall: {Hall}".PadRight(innerWidth)                + " *\n";
        ticket += "* " + $"Date: {Date:yyyy-MM-dd HH:mm}".PadRight(innerWidth) + " *\n";

        foreach (var line in seatLines)
            ticket += "* " + line.PadRight(innerWidth) + " *\n";

        ticket += "* " + $"Total: €{TotalPrice:F2}".PadRight(innerWidth)    + " *\n";
        ticket += border;

        return ticket;
    }
    
}
