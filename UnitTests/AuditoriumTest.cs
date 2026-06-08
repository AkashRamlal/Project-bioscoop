namespace UnitTests;

[TestClass]
public class AuditoriumTests
{
    [TestMethod]
    public void CancelTicketRemoveFromDict()
    {
        //Arange
        Auditorium auditorium = new Auditorium("Auditorium 1");
        string showKey = "Movie-Friday 29 May - 12:00-Auditorium 1";

        auditorium.ReservedSeats[showKey] = new Dictionary<string, decimal>();
        auditorium.ReservedSeats[showKey]["A1"] = 11.00M;

        List<string> cancelledSeat = ["A1"];

        // Act
        auditorium.Cancelticket(cancelledSeat, showKey);

        // Assert
        Assert.IsFalse(auditorium.ReservedSeats[showKey].ContainsKey("A1"));


    }

    [TestMethod]
    public void TestSetReservedSeats()
    {
        // Arange
        Auditorium auditorium = new Auditorium("Auditorium 1");

        List<string> seats = ["E7"];

        // Act
        auditorium.SetReservedSeats(seats);
        //Assert
        Assert.AreEqual(4, auditorium._seats[4, 6]);
    }

    [TestMethod]

    public void TestAToNUM()
    {
        // arrange
        Auditorium auditorium = new Auditorium("Auditorium 1");
        string seat = "E4";

        // Act
        var final = auditorium.AToNum(seat);

        // Assert
        Assert.AreEqual((4, 3), final);
    }

    [TestMethod]
    public void TestLayout()// niet via de method maar via innstrutor
    {
        // Arrange
        Auditorium auditorium = new("Auditorium 1");

        // Assert
        Assert.AreEqual(14, auditorium._seats.GetLength(0));
        Assert.AreEqual(12, auditorium._seats.GetLength(1));
    }

    [TestMethod]
    public void TestAddingToDict()
    {
        // Arrange
        Auditorium auditorium = new("Auditorium 1");
        string showKey = "Movie-Friday 29 May - 12:00-Auditorium 1";

        auditorium.ReservedSeats[showKey] = new Dictionary<string, decimal>();

        // Act
        auditorium.AddingToDict(1, "A1", showKey);

        // Assert
        Assert.AreEqual(11.00M, auditorium.ReservedSeats[showKey]["A1"]);

    }
}
