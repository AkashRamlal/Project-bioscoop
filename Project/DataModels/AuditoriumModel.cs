public class AuditoriumModel
{
    public string Number { get;}
    public SeatType[,] Seats { get; }
    

    public AuditoriumModel(string number, SeatType[,] seats)
    {
        Number = number;
        Seats = seats;
    }
}

 // hier staat de layout van de zalen, deze wordt gebruikt in de auditorium repository om de zalen te genereren
 // in de Reservation.cs staat welke stoelen er gereserveerd zijn, deze worden gebruikt in de auditorium repository om de layout aan te passen
//in SeatsType.cs staan de verschillende soorten stoelen, deze worden gebruikt in de auditorium repository om de layout aan te passen en in de reservation.cs om de prijs van de stoelen te bepalen