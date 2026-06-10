namespace UnitTests;

[TestClass]
public class AuditoriumTests
{
    private AuditoriumService CreateService()
    {
        AuditoriumRepository repository = new AuditoriumRepository();
        return new AuditoriumService(repository);
    }

    [TestMethod]
    public void CancelTicketRemoveFromDict()
    {
        // Arrange
        AuditoriumService service = CreateService();
        AuditoriumModel auditorium = service.LoadAuditorium("Auditorium 1");

        Reservation reservation = new Reservation
        {
            AuditoriumNumber = "Auditorium 1",
            Showkey = "MaoZeDong-Friday 29 May - 12:00-Auditorium 1"
        };

        reservation.Seats["E7"] = 12.00m;
        auditorium.Seats[4, 6] = SeatType.Reserved;

        List<string> cancelledSeats = ["E7"] ;

        // Act
        service.Cancelticket(auditorium, reservation, cancelledSeats);

        // Assert
        Assert.IsFalse(reservation.Seats.ContainsKey("E7"));
        Assert.AreEqual(SeatType.Comfort, auditorium.Seats[4, 6]);
    }

    [TestMethod]
    public void TestSetReservedSeats()
    {
        // Arrange
        AuditoriumService service = CreateService();
        AuditoriumModel auditorium = service.LoadAuditorium("Auditorium 1");

        List<string> seats = ["E7"];

        // Act
        service.SetReservedSeats(auditorium, seats);

        // Assert
        Assert.AreEqual(SeatType.Reserved, auditorium.Seats[4, 6]);
    }

    [TestMethod]
    public void TestSeatToIndexes()
    {
        // Arrange
        AuditoriumService service = CreateService();
        string seat = "E4";

        // Act
        var final = service.SeatToIndexes(seat);

        // Assert
        Assert.AreEqual((4, 3), final);
    }

    [TestMethod]
    public void TestLayout()
    {
        // Arrange
        AuditoriumService service = CreateService();

        // Act
        AuditoriumModel auditorium = service.LoadAuditorium("Auditorium 1");

        // Assert
        Assert.AreEqual(14, auditorium.Seats.GetLength(0));
        Assert.AreEqual(12, auditorium.Seats.GetLength(1));
    }

    [TestMethod]
    public void TestBookSeatAddsToReservation()
    {
        // Arrange
        AuditoriumService service = CreateService();
        AuditoriumModel auditorium = service.LoadAuditorium("Auditorium 1");

        Reservation reservation = new Reservation 
        {
            AuditoriumNumber = "Auditorium 1",
            Showkey = "Movie-Friday 29 May - 12:00-Auditorium 1"
        };

        // Act
        service.BookSeat(auditorium, reservation, 4, 6);

        // Assert
        Assert.AreEqual(12.00m, reservation.Seats["E7"]);
        Assert.AreEqual(SeatType.Reserved, auditorium.Seats[4, 6]);
    }
}