using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TicketTests
{
    [TestMethod]
    public void Constructor_SetsFilmName()
    {
        var ticket = new Ticket("Inception", "Hall 1", "19:00", "A1 (€10.00)", 10.00m);
        Assert.AreEqual("Inception", ticket.FilmName);
    }

    [TestMethod]
    public void Constructor_SetsHall()
    {
        var ticket = new Ticket("Film", "Hall 2", "19:00", "A1", 10.00m);
        Assert.AreEqual("Hall 2", ticket.Hall);
    }

    [TestMethod]
    public void Constructor_SetsTime()
    {
        var ticket = new Ticket("Film", "Hall 1", "21:30", "A1", 10.00m);
        Assert.AreEqual("21:30", ticket.Time);
    }

    [TestMethod]
    public void Constructor_SetsSeats()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "B3 (€15.00)", 15.00m);
        Assert.AreEqual("B3 (€15.00)", ticket.Seats);
    }

    [TestMethod]
    public void Constructor_SetsTotalPrice()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 42.50m);
        Assert.AreEqual(42.50m, ticket.TotalPrice);
    }

    [TestMethod]
    public void Constructor_SetsAccountId()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m, 7);
        Assert.AreEqual(7, ticket.AccountId);
    }

    [TestMethod]
    public void Constructor_DefaultAccountId_IsZero()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m);
        Assert.AreEqual(0, ticket.AccountId);
    }

    [TestMethod]
    public void DefaultConstructor_HasEmptyStrings()
    {
        var ticket = new Ticket();
        Assert.AreEqual("", ticket.FilmName);
        Assert.AreEqual("", ticket.Hall);
        Assert.AreEqual("", ticket.Time);
        Assert.AreEqual("", ticket.Seats);
    }

    [TestMethod]
    public void DefaultConstructor_HasZeroId()
    {
        var ticket = new Ticket();
        Assert.AreEqual(0, ticket.Id);
    }

    [TestMethod]
    public void PrintTicket_ContainsFilmName()
    {
        var ticket = new Ticket("Inception", "Hall 1", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("Inception"));
    }

    [TestMethod]
    public void PrintTicket_ContainsHall()
    {
        var ticket = new Ticket("Film", "Hall 3", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("Hall 3"));
    }

    [TestMethod]
    public void PrintTicket_ContainsTime()
    {
        var ticket = new Ticket("Film", "Hall 1", "21:30", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("21:30"));
    }

    [TestMethod]
    public void PrintTicket_ContainsSeats()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "C5 (€12.00)", 12.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("C5"));
    }

    [TestMethod]
    public void PrintTicket_ContainsTotalPrice()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 25.50m);
        string result = ticket.PrintTicket();
        // Accept both decimal separators depending on system locale
        Assert.IsTrue(result.Contains("25,50") || result.Contains("25.50"));
    }

    [TestMethod]
    public void PrintTicket_ContainsBorderStars()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("****"));
    }

    [TestMethod]
    public void PrintTicket_ContainsReservationLabel()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("Reservation"));
    }

    [TestMethod]
    public void PrintTicket_IsMultiline()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains('\n'));
    }

    [TestMethod]
    public void PrintTicket_ContainsTotalLabel()
    {
        var ticket = new Ticket("Film", "Hall 1", "19:00", "A1", 10.00m);
        Assert.IsTrue(ticket.PrintTicket().Contains("Total"));
    }
}
