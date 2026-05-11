// LAYER: Logic (Model)
public class Ticket
{
    public int Id { get; set; } = 0;
    public string FilmName { get; set; } = "";
    public string Hall { get; set; } = "";
    public string Time { get; set; } = "";
    public string Seats { get; set; } = "";
    public decimal TotalPrice { get; set; }
    public int AccountId { get; set; }

    public Ticket() { } // For Dapper

    public Ticket(string filmName, string hall, string time, string seats, decimal totalPrice, int accountId = 0)
    {
        FilmName = filmName;
        Hall = hall;
        Time = time;
        Seats = seats;
        TotalPrice = totalPrice;
        AccountId = accountId;
    }
    public string PrintTicket()
    {
        int width = 60;
        string border = new string('*', width);

        string resLine   = $"Reservation #: {Id}".PadRight(width - 4);
        string filmLine  = $"Film: {FilmName}".PadRight(width - 4);
        string hallLine  = $"Hall: {Hall}".PadRight(width - 4);
        string timeLine  = $"Time: {Time}".PadRight(width - 4);
        string seatsLine = $"Seats: {Seats}".PadRight(width - 4);
        string priceLine = $"Total: €{TotalPrice:F2}".PadRight(width - 4);

        string ticket = border + "\n";
        ticket += "* " + resLine   + " *\n";
        ticket += "* " + filmLine  + " *\n";
        ticket += "* " + hallLine  + " *\n";
        ticket += "* " + timeLine  + " *\n";
        ticket += "* " + seatsLine + " *\n";
        ticket += "* " + priceLine + " *\n";
        ticket += border;

        return ticket;
    }
}
