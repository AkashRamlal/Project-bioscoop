// LAYER: Logic (Model)
public class Ticket
{
    private static int _reservationCounter = 0;

    // Call this once at app startup if you want to set a starting number
    public static void SetCounter(int lastNumber)
    {
        _reservationCounter = lastNumber;
    }

    public int ReservationNumber { get; private set; }
    public string FilmName { get; set; } = "";
    public string Hall { get; set; } = "";
    public string Time { get; set; } = "";
    public string Seats { get; set; } = "";
    public decimal TotalPrice { get; set; }

    public Ticket(string filmName, string hall, string time, string seats, decimal totalPrice)
    {
        ReservationNumber = ++_reservationCounter;
        FilmName = filmName;
        Hall = hall;
        Time = time;
        Seats = seats;
        TotalPrice = totalPrice;
    }

    public string PrintTicket()
    {
        int width = 60;
        string border = new string('*', width);

        string resLine   = $"Reservation #: {ReservationNumber}".PadRight(width - 4);
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
